using es.eit.model.Entitities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace es.eit.data.Sql.Implementations.Contexts.Initializers
{
    public class SeedDatabaseInitializer : CreateDatabaseIfNotExists<EIT_Context>
    {
        protected override void Seed( EIT_Context context )
        {
            IList<Department> defaultDepartments = new List<Department>
                {
                    new Department
                    {
                        Id = 1,
                        Name = "Arquitectura",
                        PersonList = new List<Person> {
                            new Person { Id = 1, IdDepartment = 1, Name = "Alberto", BirthDate = new DateTime(1980,01,01), Salary = 1100.11M },
                            new Person { Id = 2, IdDepartment = 1, Name = "Andrés",                                        Salary = 1200.12M  }
                        },
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "Desarrollo",
                        PersonList = new List<Person> {
                            new Person { Id = 3, IdDepartment = 2, Name = "Darío",  BirthDate = new DateTime(1990,02,01), Salary = 2100.21M },
                            new Person { Id = 4, IdDepartment = 2, Name = "David",  BirthDate = new DateTime(1990,02,02), Salary = 2200.22M },
                            new Person { Id = 5, IdDepartment = 2, Name = "Damian",                                       Salary = 2300.23M }
                        },
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "Recursos Humanos",
                        PersonList = new List<Person> {
                            new Person { Id = 6, IdDepartment = 3, Name = "Raúl",     BirthDate = new DateTime(2000,03,01), Salary = 3100.31M },
                            new Person { Id = 7, IdDepartment = 3, Name = "Ricardo",  BirthDate = new DateTime(2000,03,02), Salary = 3200.32M },
                            new Person { Id = 8, IdDepartment = 3, Name = "Roberto",  BirthDate = new DateTime(2000,03,03), Salary = 3300.33M },
                            new Person { Id = 9, IdDepartment = 3, Name = "Reinaldo",                                       Salary = 3400.34M }
                        },
                    },
                };

            context.Departments.AddRange( defaultDepartments );

            base.Seed( context );
        }
    }
}
