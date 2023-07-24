#!/bin/bash

# Cargar las variables desde el archivo 'variables.sh'
source ./variables.sh

# CONFIGURACION PARA CREAR CONTENEDOR PARA BRYAN (DESCOMENTAR, CASOS ESPECIALES)
# docker pull mcr.microsoft.com/azure-sql-edge:latest
# docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD='$MSSQL_SA_PASSWORD'' -p 1433:1433 --name $CONTENEDOR_NAME -d mcr.microsoft.com/azure-sql-edge:latest

# COMANDO PARA COPIAR RESPALDO AL CONTENEDOR
# docker cp "$LOCAL_PATH_BACKUP" "$CONTENEDOR_NAME":"$CONTAINER_DB_PATH"

# COPIAR COMANDO Y EJECUTARLO MANUALMENTE
# RESTORE DATABASE neptuno FROM DISK = '/var/backups/neptuno.bak' WITH MOVE 'NeptunoModelo_Data' TO '/var/opt/mssql/data/NeptunoImpSelectas.mdf', MOVE 'NeptunoModelo_FG2' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.mdf', MOVE 'NeptunoModelo_FG3' TO '/var/opt/mssql/data/NeptunoImpSelectas_2.mdf', MOVE 'NeptunoModelo_Log' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.ldf', REPLACE, STATS=5;

# COMANDO PARA RESTAURAR DIRECTAMENTE DESDE EL CONTENEDOR
# docker exec -it $CONTENEDOR_NAME /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -Q "RESTORE DATABASE neptuno FROM DISK = '/var/backups/neptuno.bak' WITH MOVE 'NeptunoModelo_Data' TO '/var/opt/mssql/data/NeptunoImpSelectas.mdf', MOVE 'NeptunoModelo_FG2' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.mdf', MOVE 'NeptunoModelo_FG3' TO '/var/opt/mssql/data/NeptunoImpSelectas_2.mdf', MOVE 'NeptunoModelo_Log' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.ldf', REPLACE, STATS=5;"

# echo "Hola $MSSQL_SA_PASSWORD"
