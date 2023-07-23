# 1 ejecutar el comando:
source restore.sh

# 2 conectarse al sql server con las credencias y ejecutar el siguiente script
RESTORE DATABASE neptuno FROM DISK = '/var/backups/neptuno.bak' WITH MOVE 'NeptunoModelo_Data' TO '/var/opt/mssql/data/NeptunoImpSelectas.mdf', MOVE 'NeptunoModelo_FG2' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.mdf', MOVE 'NeptunoModelo_FG3' TO '/var/opt/mssql/data/NeptunoImpSelectas_2.mdf', MOVE 'NeptunoModelo_Log' TO '/var/opt/mssql/data/NeptunoImpSelectas_1.ldf', REPLACE, STATS=5;