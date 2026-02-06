SELECT TOP 100 * 
FROM OPENROWSET( BULK 'https://staclab4.dfs.core.windows.net/raw/*.parquet', 
                FORMAT = 'PARQUET ) 
                AS rows;

df = spark.read.parquet(
        "abfss://raw@staclab4.dfs.core.windows.net/raw/all/order_events.parquet"
        )
df.printSchema() 
df.show(5)
df_dedup = df.dropDuplicates()
print(df.count())
print(df_dedup.count())

SELECT TOP 100 *
FROM OPENROWSET(
    BULK 'https://staclab4.dfs.core.windows.net/raw/all/order_events.parquet',
    FORMAT = 'PARQUET'
) AS rows;

from pyspark.sql.functions import to_timestamp
df_clean = df_dedup.withColumn(  "event_time",  to_timestamp("event_time"))

df = spark.read.parquet(
        "abfss://raw@staclab4.dfs.core.windows.net/all/order_events.parquet"
        )

from pyspark.sql.functions import col
from pyspark.sql.types import TimestampType

for field in df.schema.fields:
    if isinstance(field.dataType, TimestampType):
        df = df.withColumn(
            field.name,
            col(field.name).cast("timestamp")
        )

spark.conf.set(
    "spark.sql.parquet.outputTimestampType",
    "TIMESTAMP_MICROS"
)

df.write.mode("overwrite").parquet(
    "abfss://raw@staclab4.dfs.core.windows.net/all_fixed/order_events"
)

df = spark.read.parquet(
    "abfss://raw@staclab4.dfs.core.windows.net/all_fixed/order_events"
)


df.printSchema() 
df.show(5)