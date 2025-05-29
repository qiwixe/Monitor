5.2.4
=====
BUG FIXES
---------
 - Allow partition_data functions and procedure to work when the source table is in a different schema than the partition table. (Github Issue #726)
 - Removed SECURITY DEFINER from the last two functions that still had it lingering. (Github Issue #512)


5.2.3
=====
BUG FIXES
---------
 - Fixed replica identity inheritance not working when the USING INDEX clause is used to set the replica identity of the parent table. (Github Issue #721)


5.2.2
=====
BUG FIXES
---------
 -  Corrected SQL statements and updated functions missing from the 5.1.0 to 5.2.0 update files. If pg_partman was installed initially with 5.2.0, there are no known issues. If errors about missing functions or columns are encountered during maintenance after updating to 5.2.x, please make sure you are on this latest release. Thank you to all the users helping to test this issues! (Github Issue #718)


5.2.1
=====
BUG FIXES
---------
 - Corrected a syntax error in the 5.1.0 to 5.2.0 update file. There are no problems with a direct install of 5.2.0 and there is no technical need to update to 5.2.1. The issue was encountered only when updating from any prior version to 5.2.0. New release was tagged to ease rolling out the fix for package managers. (Github Issue #711)


5.2.0
=====
NEW FEATURES
------------
 - Add support for UUIDv7 and other custom encoded methods for time-based partitioning. Special thanks to akulapid on Github for the addition of this feature. (Github Issue #528)
 - Add support for microsecond precisions in epoch partitioning. (Github PR #659)
 - Improve partition maintenance performance when determining next partition to be created. (Github Issue #660)
 - Removed requirement for pg_partman to be installed as a superuser. See "superuser" parameter in control file documentation for more details - https://www.postgresql.org/docs/current/extend-extensions.html#EXTEND-EXTENSIONS-FILES
 - Do not create partitions during a maintenance run that aren't going to be kept as part of retention anyway. (Github Issue #649)
 - Removed `default_table` column from `part_config` table. It's only necessary in `part_config_sub` to determine whether future sub-partition parents should have defaults made. Adjusted other code to look up whether a default table actually exists to determine its behavior. (Github Issue #637)
 - Allow the control column to be NULL. This is not advised without very careful review and an explicit use-case defined as it can cause unexpected behavior or excessive data in the DEFAULT child partition. A new flag `p_control_not_null` has been added to the `create_parent()` and `create_sub_parent()` functions.
- Include the following additional parent table properties on newly created child tables: COMPRESSION, STORAGE, and STATISTICS. Note this is only for newly created child tables. Existing child tables will have to be updated manually. (Github Issue #683)

BUG FIXES
---------
 - Enforcement of the control column being NOT NULL was not being done as intended. This has been fixed. If you'd like to allow the control column to be NULL, see the new feature flag in 5.2.0
 - Fixed handling of bigint data type with LIST partitioning. New partitions were not being created during maintenance and `show_*` functions were not giving expected results. (Github Issue #704)
 - Fixed `reapply_constraint_proc()` to work properly when there are no relevant child tables to place additional constraints. In the process reworked the logic to determine the target child tables for both that procedure and the apply_constraints() function. The determining factor is now always the newest child table that contains data (other than the default). Updated documentation to clarify how the optimize_constraint flag works. (Github Issue #694)
 - Properly handle partial indexes that are inherited from the template table. (Github Issue #657)
 - Move the retention logic for dropping tables later in the maintenance process to help avoid longer running heavy locks on partition sets. (Github Issue #678)

5.1.0
=====
NEW FEATURES
------------
 - Support LIST partitioning for single value integers. (Issue #236)
 - Add explicit ordering of partition set maintenance. (Issue #497)
    - A new column has been added to the `part_config` table: `maintenance_order`. If set, the partition sets will run in increasing numerical order
    - Defaults to NULL and has no requirement
    - NULL values will always come after numbered sets in no guaranteed order
 - Added new column `part_config.maintenance_last_run` to track the last datetime that maintenance was run for that partition set. Timestamp is only updated if maintenance for that partition set completed successfully so can be used as a monitoring metric.
 - REPLICA IDENTITY is now automatically inherited from the parent table to all children (#502)
    - Note for existing partition sets, this will only apply to newly created child tables. Existing child tables will need to be manually updated.
 - EXPERIMENTAL - Support numeric partitioning (Issue #265)
    - Note that while the partition column may now be of type numeric, the partitioning interval must still be a whole integer value
    - Please evaluate this feature carefully before using in production and feel free to open issues or discussions on the Github repository for both positive and negative feedback. Positive feedback will speed up moving this feature out of experimental.

BUGFIXES
--------
 - Remove child tables from publication during retention that keeps tables (Github Issue #523)
 - Allow partition maintenance to be called on replicas without error. Calling maintenance on a replica will do nothing and exit cleanly. Allows for setting up consistent cronjobs between failover systems. (Github Issue #569)
 - Properly inherit tablespaces (Github Issue #609)
    - This was a regression in 5.0 that mistakenly stopped working. Tablespace inheritance still works as expected in 4.x.
 - Allow `infinite_time_partitions` flag to work even if the partition set has no data. This can happen in partition sets with retention and low data writes (Github Issue #585)
 - Fixed edge case where partition sets with zero data would still get new partitions created. Triggered by partman maintaining multiple partition sets and maintenance running on one that had data followed by one that did not.
 - Fixed `partition_data` functions throwing an error if the source table was not in the same schema as the parent table. (Github Issue #639)


4.8.0
=====
BUG FIXES
---------
 - Added `pg_analyze` parameter to `partition_gap_fill` function to allow skipping the analyze of a partition set if the gap fill actually creates new partitions. Note this is not an option in 5.x since the analyze step was refactored and never runs automatically during a call to the gap fill function anymore.
 - Note that there is no way to directly install version 4.8.0. A prior version must be installed first and then upgraded to 4.8.0. It is recommended that you migrate to the latest major version for continued support of pg_partman.


5.0.0 & 5.0.1
=============
UPGRADE NOTES
-------------
 - The upgrade to 5.x had to be split into two parts to allow certain transaction limiting conditions to be met. Please see [pg_partman_5.0.1_upgrade.md](doc/pg_partman_5.0.1_upgrade.md) if you run into any errors concerning triggers when trying to update. There is no standalone version of 5.0.0 for pg_partman any longer and all users should update to 5.0.1.
    - If you have already successfully upgraded to version 5.0.0, the update to 5.0.1 will not introduce any changes. The new minor version is to allow for the staged upgrade.
 - It is recommended that you take a backup of the `part_config` and `part_config_sub` tables before upgrading just to ensure they can be restored in case there are any issues. These tables are recreated as part of the upgrade.
   - If you see any errors about the following tables existing during an upgrade attempt, please review their content and ensure you do not need any of the backed up pre-5.x configuration data they contain. Drop them if not needed and try the upgrade again: `part_config_pre_500_data`, `part_config_sub_pre_500_data`
 - Many thanks to all the people that have helped with testing and code review during 5.x development. In particular...
    - Leigh Downs and the team at Crunchy Data for extensive testing
    - vitaly-burovoy on Github for some amazing optimizations and code review
    - andyatkinson on Github for documentation review and pointing out my antiquated usage of the term "native" now that there's only one partitioning method supported
    - hyde1 on Github for finding the upgrade issue and a simpler upgrade method for 5.0.1
    - And as always to [pgTAP](https://pgtap.org/) for making testing so much easier

BREAKING CHANGES
----------------
 - Removed trigger-based partitioning support. All partitioning is now done using built-in declarative partitioning. The partitioning `type` in pg_partman will now refer to the types of declarative partitioning that are supported. As of 5.0.1, only `range` is supported, but others are in development (Github Issue #490).
    - See [migrate_to_declarative.md](doc/migrate_to_declarative.md) for assistance on migrating off trigger-based partitioning.
 - Many functions have had their parameters altered, renamed, rearranged or removed. These should be more consistent across the code-base now. Please review ALL calls to pg_partman functions to ensure that your parameter names and values have been updated to match the changes.
    - The `part_config` and `part_config_sub` tables have had some columns removed and rearranged to only contain supported features.
 - Due to a majority of extension objects being dropped & recreated, privileges on the extension objects ARE NOT being preserved as they have been done with past extension updates. Ensure existing privileges are recorded before upgrading pg_partman and are regranted/revoked after the upgrade is complete. Check the following system catalogs for privilege information for pg_partman objects: `information_schema.routine_privileges` & `information_schema.table_privileges`
 - Some specialized time-based interval types have been deprecated. See [pg_partman_5.0.1_upgrade.md](doc/pg_partman_5.0.1_upgrade.md) for additional guidance on migrating unsupported partition methods to supported ones.
    - All time-based interval values must now be valid values for the interval data type. The previous weekly, hourly, daily, etc interval values are no longer supported.
    - Removed specialized quarterly partitioning (see [5.0.1 migration doc](doc/pg_partman_5.0.1_upgrade.md)).
    - Removed specialized weekly partitioning with ISO style week numbers (see [5.0.1 migration doc](doc/pg_partman_5.0.1_upgrade.md)).
    - Hourly partitioning now has seconds on the child partition suffix. Migration for this is not necessary, but just be aware that any new partition sets created with this interval may look different than existing ones from prior pg_partman versions.
 - The minimum required version of PostgreSQL is now 14
    - Required for calling procedures via background worker (Github PR #242).
 - Dropped automatic publication refresh of a partition set that was part of a logical replication subscription. As of PostgreSQL 14, it is no longer possible to call ALTER SUBSCRIPTION ... REFRESH PUBLICATION within a transaction block which means it can no longer be called via the maintenance functions. For now, an independent call with this refresh statement will need to be done on the subscription side of partition sets that are part of logical replication (Github Issue #572).
 - The partition control column being NOT NULL is now fully enforced when making new partition sets.

NEW FEATURES
------------
 - Changed all usage of the term "native" to "declarative" to better match upstream PostgreSQL terminology for built-in partitioning.
 - Simplified all time-based partitioning suffixes to `YYYYMMDD` for intervals greater than or equal to 1 day and `YYYYMMDD_HH24MISS` for intervals less than 1 day. Removed extra underscores to allow longer base partition names. Existing partition suffixes will still be supported, but newly created partition sets will use the new naming patterns by default. It is recommended that migration to the new suffixes is done when possible to ensure future support of possible pg_partman changes. The [documentation](doc/pg_partman_5.0.1_upgrade.md) on migrating the old specialized weekly/quarterly partition sets to be supported in 5.0.1 can be used as guidance for migrating other child table names as well.
 - By default, data in the default partition is now ignored when calculating new child partitions to create. If a new child table's boundaries would include data that exists in the default, this will cause an error during maintenance and must be manually resolved by either removing that data from the default or partitioning it out to the proper child table using the partition_data function/procedure.
    - A flag is available to take default data into consideration, but this should only be used in rare circumstances to correct maintenance issues and should not be left permanently enabled for ideal partition maintenance.
 - Added option to make default table optional during partition creation (`p_default_table`) (Github Issue #489).
 - As of PostgreSQL 13, newly created child tables in a partition set that is part of a logical replication PUBLICATION are automatically added to that PUBLICATION. Therefore the "publications" array configuration in the pg_partman configuration tables was removed. Simply make sure the parent table is a part of the necessary publications and it will be automatically handled by core PostgreSQL from now on (Github Issue #520)
    - Note the SUBSCRIPTION does not automatically get refreshed to account for new tables added to a published partition set. See note above in BREAKING CHANGES concerning subscription side refreshes.
 - Added support for dropping indexes for partitions moved to another schema as part of retention (Github PR #449).
 - Creating a template table is now optional when calling `create_parent()`. Set `p_template_table` to `false` to skip template table creation. Note this is not a boolean since this parameter is also meant to take a template table name, so the explicit string value `false` must be set (Github Issue #505).
 - Lots of backend optimizations and code simplification
 - Allow overriding of the PG_CONFIG environment variable when running make (Github PR #589).

BUG FIXES
---------
 - Edge case with `infinite_time_partitions` fixed. If set to true and data far ahead of "now" was inserted, no new child tables would be created based on the premake.
 - Make errors from `show_partition_info()` clearer (Github Issue #542).
 - Ensure the bgw_type value is properly set in the Background Worker structs (Github Issue #573).


For CHANGELOGs prior to version 5.0.0, see CHANGELOG-pre-5.0.0.txt
