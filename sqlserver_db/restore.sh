# Nombre del archivo .bak a restaurar
CONTENEDOR_NAME="sqlserver_db"
CONTAINER_DB_PATH="/var/backups/neptuno.bak"
SCRIPT_DB="restore_db.sh"
BACKUP_NAME="neptuno.bak"
LOCAL_PATH_BACKUP="./backup/neptuno.bak"
MSSQL_SA_PASSWORD="M1n0T4ur0"

docker pull mcr.microsoft.com/azure-sql-edge:latest

docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD='$MSSQL_SA_PASSWORD'' -p 1433:1433 --name $CONTENEDOR_NAME -d mcr.microsoft.com/azure-sql-edge:latest

docker cp "$LOCAL_PATH_BACKUP" "$CONTENEDOR_NAME":"$CONTAINER_DB_PATH"

# RESTORE DATABASE neptuno FROM DISK = '/var/backups/neptuno.bak' WITH MOVE 'NeptunoModelo_Data' TO '/var/opt/mssql/data/NeptunoImpSelectas.mdf', MOVE 'NeptunoModelo_FG2' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.mdf', MOVE 'NeptunoModelo_FG3' TO '/var/opt/mssql/data/NeptunoImpSelectas_2.mdf', MOVE 'NeptunoModelo_Log' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.ldf', REPLACE, STATS=5;