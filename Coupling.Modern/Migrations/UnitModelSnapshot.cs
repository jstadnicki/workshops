using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Coupling.Modern.Repository;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace Coupling.Modern.Migrations
{
    [DbContext(typeof(Unit))]
    partial class UnitModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

            modelBuilder.Entity("Coupling.Modern.DataModels.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarType");

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Key("Id");
                });
        }
    }
}
