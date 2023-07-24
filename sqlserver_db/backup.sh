#!/bin/bash

# Cargar las variables desde el archivo 'variables.sh'
source ./variables.sh

# COMANDO PARA COPIAR RESPALDO AL CONTENEDOR
docker cp "$LOCAL_PATH_BACKUP" "$CONTENEDOR_NAME":"$CONTAINER_DB_PATH"