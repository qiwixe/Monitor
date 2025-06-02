-- ########## TIME MONTHLY ##########
-- Other tests:
    -- Test source table in a different schema
    -- Test generate always as identity in source and target (ignore column)

\set ON_ERROR_ROLLBACK 1
\set ON_ERROR_STOP true

BEGIN;
SELECT set_config('search_path','partman, public',false);

SELECT plan(81);
CREATE SCHEMA partman_test;
CREATE SCHEMA partman_source;
CREATE SCHEMA partman_retention_test;

CREATE TABLE partman_test.time_taptest_table
    (col1 int NOT NULL GENERATED ALWAYS AS IDENTITY
     , col2 text
     , col3 timestamptz DEFAULT now() NOT NULL)
    PARTITION BY RANGE (col3);
CREATE TABLE partman_test.time_taptest_table_template (LIKE partman_test.time_taptest_table INCLUDING ALL);
ALTER TABLE partman_test.time_taptest_table_template ADD PRIMARY KEY (col1);
CREATE TABLE partman_test.undo_taptest (LIKE partman_test.time_taptest_table INCLUDING ALL);

CREATE INDEX ON partman_test.time_taptest_table (col3);

CREATE TABLE partman_source.time_taptest_table_source (LIKE partman_test.time_taptest_table INCLUDING ALL);

INSERT INTO partman_source.time_taptest_table_source (col3) VALUES (generate_series(CURRENT_TIMESTAMP-'12 months'::interval, CURRENT_TIMESTAMP, '1 day'::interval));

SELECT results_eq('SELECT count(*)::int FROM partman_source.time_taptest_table_source', ARRAY[367], 'Ensure source has expected row count');

SELECT create_parent('partman_test.time_taptest_table', 'col3', '1 month', p_template_table => 'partman_test.time_taptest_table_template');

SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD'), 'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'1 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'1 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'2 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'2 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'3 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'3 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'4 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'4 month'::interval, 'YYYYMMDD')||' exists');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'1 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'1 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'2 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'2 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'4 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'4 month'::interval, 'YYYYMMDD')||' exists');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD')||' does not exist');

SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'1 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'1 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'2 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'2 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'3 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'3 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'4 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'4 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'1 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'1 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'2 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'2 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'4 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'4 month'::interval, 'YYYYMMDD'));

SELECT results_eq('SELECT partman.partition_data_time(''partman_test.time_taptest_table'', ''20'', p_source_table := ''partman_source.time_taptest_table_source'', p_ignored_columns := ARRAY[''col1''])::int', ARRAY[367], 'Move data out of source table into partitioned table');

SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'6 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'6 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'7 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'7 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'8 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'8 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'9 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'9 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'10 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'10 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'11 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'11 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'12 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'12 month'::interval, 'YYYYMMDD')||' exists');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'13 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'13 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'6 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'6 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'7 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'7 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'8 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'8 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'9 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'9 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'10 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'10 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'11 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'11 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'12 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'12 month'::interval, 'YYYYMMDD'));


SELECT results_eq('SELECT count(*)::int FROM partman_test.time_taptest_table', ARRAY[367], 'Ensure source has expected row count');
SELECT is_empty('SELECT col1 FROM partman_source.time_taptest_table_source', 'Ensure source is now empty');


UPDATE part_config SET premake = 5 WHERE parent_table = 'partman_test.time_taptest_table';
SELECT run_maintenance();

INSERT INTO partman_test.time_taptest_table (col3) VALUES (CURRENT_TIMESTAMP + '5 month'::interval);
INSERT INTO partman_test.time_taptest_table (col3) VALUES (CURRENT_TIMESTAMP + '5 month'::interval);

SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD')||' exists');

SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'6 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'6 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'));

SELECT results_eq('SELECT count(*)::int FROM partman_test.time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'),
    ARRAY[2], 'Check count from time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'));

UPDATE part_config SET premake = 6 WHERE parent_table = 'partman_test.time_taptest_table';
SELECT run_maintenance();
INSERT INTO partman_test.time_taptest_table (col3) VALUES (CURRENT_TIMESTAMP + '6 month'::interval);
INSERT INTO partman_test.time_taptest_table (col3) VALUES (CURRENT_TIMESTAMP + '6 month'::interval);
INSERT INTO partman_test.time_taptest_table (col3) VALUES (CURRENT_TIMESTAMP + '6 month'::interval);

SELECT results_eq('SELECT count(*)::int FROM partman_test.time_taptest_table', ARRAY[372], 'Check count from parent table');
SELECT results_eq('SELECT count(*)::int FROM partman_test.time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'6 month'::interval, 'YYYYMMDD'),
    ARRAY[3], 'Check count from time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'6 month'::interval, 'YYYYMMDD'));

SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'10 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'10 month'::interval, 'YYYYMMDD')||' exists');
SELECT has_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'11 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'11 month'::interval, 'YYYYMMDD')||' exists');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'12 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'12 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'10 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'10 month'::interval, 'YYYYMMDD'));
SELECT col_is_pk('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'11 month'::interval, 'YYYYMMDD'), ARRAY['col1'],
    'Check for primary key in time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'11 month'::interval, 'YYYYMMDD'));

SELECT drop_partition_time('partman_test.time_taptest_table', '3 month', p_keep_table := false);
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'4 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'4 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'5 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'6 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'6 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'7 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'7 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'8 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'8 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'9 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'9 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'10 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'10 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'11 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'11 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'12 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'12 month'::interval, 'YYYYMMDD')||' does not exist');

UPDATE part_config SET retention = '2 month'::interval WHERE parent_table = 'partman_test.time_taptest_table';
SELECT drop_partition_time('partman_test.time_taptest_table', p_retention_schema := 'partman_retention_test');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT has_table('partman_retention_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'3 month'::interval, 'YYYYMMDD')||' got moved to new schema');

SELECT undo_partition('partman_test.time_taptest_table', p_loop_count => 20, p_target_table := 'partman_test.undo_taptest', p_keep_table := false, p_ignored_columns := ARRAY['col1'] );
SELECT results_eq('SELECT count(*)::int FROM partman_test.undo_taptest', ARRAY[97], 'Check count from target table after undo');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP), 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'1 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'1 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'2 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)-'2 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'1 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'1 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'2 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'2 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'3 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'3 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'4 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'4 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'5 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'6 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'6 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'7 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'7 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'8 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'8 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'9 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'9 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'10 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'10 month'::interval, 'YYYYMMDD')||' does not exist');
SELECT hasnt_table('partman_test', 'time_taptest_table_p'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'11 month'::interval, 'YYYYMMDD'),
    'Check time_taptest_table_'||to_char(date_trunc('month', CURRENT_TIMESTAMP)+'11 month'::interval, 'YYYYMMDD')||' does not exist');


SELECT hasnt_table('partman_test', 'time_taptest_table_template', 'Check that template table was dropped');

SELECT * FROM finish();
ROLLBACK;
