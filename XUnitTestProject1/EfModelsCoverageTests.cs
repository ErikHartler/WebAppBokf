using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EfLibrary.EFModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Xunit;

namespace XUnitTestProject1
{
    public class EfModelsCoverageTests
    {
        public static IEnumerable<object[]> ModelTypes =>
            typeof(Betalsatt).Assembly
                .GetTypes()
                .Where(type => type.Namespace == typeof(Betalsatt).Namespace && type.IsClass && !type.IsAbstract)
                .OrderBy(type => type.Name)
                .Select(type => new object[] { type });

        [Theory]
        [MemberData(nameof(ModelTypes))]
        public void PublicPropertiesCanBeSetAndRead(Type modelType)
        {
            var model = Activator.CreateInstance(modelType);
            Assert.NotNull(model);

            var properties = modelType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(property => property.GetMethod?.IsPublic == true && property.SetMethod?.IsPublic == true)
                .ToArray();
            Assert.NotEmpty(properties);

            foreach (var property in properties)
            {
                var value = CreateSampleValue(property.PropertyType);
                property.SetValue(model, value);
                Assert.Equal(value, property.GetValue(model));
            }
        }

        [Theory]
        [MemberData(nameof(ModelTypes))]
        public void NavigationCollectionsAreInitialized(Type modelType)
        {
            var model = Activator.CreateInstance(modelType);
            Assert.NotNull(model);

            var collectionProperties = modelType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(property => property.PropertyType != typeof(string)
                    && typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                    && property.PropertyType.IsGenericType)
                .ToArray();

            foreach (var property in collectionProperties)
            {
                var collection = property.GetValue(model) as IEnumerable;
                Assert.NotNull(collection);
                Assert.Empty(collection);
            }
        }

        [Fact]
        public void LookupSeedDataIsRegistered()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            Betalsatt.SeedData(modelBuilder);
            Enhet.SeedData(modelBuilder);
            Landskod.SeedData(modelBuilder);

            Assert.Equal(2, modelBuilder.Model.FindEntityType(typeof(Betalsatt))!.GetSeedData().Count());
            Assert.Equal(2, modelBuilder.Model.FindEntityType(typeof(Enhet))!.GetSeedData().Count());
            Assert.Equal(3, modelBuilder.Model.FindEntityType(typeof(Landskod))!.GetSeedData().Count());
        }

        private static object CreateSampleValue(Type propertyType)
        {
            var valueType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

            if (valueType == typeof(string))
            {
                return "coverage";
            }

            if (valueType == typeof(DateTime))
            {
                return new DateTime(2020, 1, 2);
            }

            if (valueType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(valueType))
            {
                var collectionType = typeof(HashSet<>).MakeGenericType(valueType.GetGenericArguments()[0]);
                return valueType.IsAssignableFrom(collectionType)
                    ? Activator.CreateInstance(collectionType)
                    : null;
            }

            return valueType.IsValueType ? Activator.CreateInstance(valueType) : null;
        }
    }
}
