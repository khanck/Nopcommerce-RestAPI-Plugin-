﻿using FluentMigrator;
using Nop.Data.Migrations;

namespace Nop.Plugin.Misc.ConnectApi.Migrations
{
    [NopMigration("", "Nop.Plugin.Misc.ConnectApi schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        private readonly IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
        }
    }
}
