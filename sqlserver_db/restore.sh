#!/bin/bash

# Cargar las variables desde el archivo 'variables.sh'
source ./variables.sh

# COMANDO PARA RESTAURAR DIRECTAMENTE DESDE EL CONTENEDOR
docker exec -it $CONTENEDOR_NAME /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -Q "RESTORE DATABASE neptuno FROM DISK = '/var/backups/neptuno.bak' WITH MOVE 'NeptunoModelo_Data' TO '/var/opt/mssql/data/NeptunoImpSelectas.mdf', MOVE 'NeptunoModelo_FG2' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.mdf', MOVE 'NeptunoModelo_FG3' TO '/var/opt/mssql/data/NeptunoImpSelectas_2.mdf', MOVE 'NeptunoModelo_Log' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.ldf', REPLACE, STATS=5;"