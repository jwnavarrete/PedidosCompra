# Use the official .NET SDK 6 base image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Set the working directory inside the container
WORKDIR /app

# Copy the application files to the container
COPY . .

EXPOSE 7041


# Restore the dependencies
# RUN dotnet restore

# Change to the app.neptuno.api directory and run the application with 'dotnet watch run'
# CMD cd app.neptuno.api && dotnet watch run