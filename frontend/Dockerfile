# Establecemos la imagen base de Node.js versión 16
FROM node:16

# Establecemos el directorio de trabajo dentro del contenedor
WORKDIR /usr/src/app

# Copiamos el archivo package.json y package-lock.json al directorio de trabajo
COPY package*.json ./

# Instalamos las dependencias de la aplicación
RUN npm install

# Copiamos el código fuente de la aplicación al directorio de trabajo
COPY . .

# Exponemos el puerto 3000 para que sea accesible desde el host
EXPOSE 3000

# Comando para iniciar la aplicación cuando el contenedor se ejecute
CMD ["npm", "run", "dev"]
