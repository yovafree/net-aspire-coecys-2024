# Instrucciones para configurar el proyecto:

### Ejecutar el proyecto de .NET Aspire
```
dotnet run --project demo3/demo3.AppHost
```

## Instrucciones para Desplegar la aplicación de .NET Aspire en Azure Container Apps

### Instalar Azure Developer CLI (AZD) en Windows

```
winget install microsoft.azd
```

### Inicializar el proyecto:

```
cd demo3/demo3.AppHost
azd init
```
### Desplegar el proyecto en Azure:
```
azd up
```

### Si realiza cambios y desea subirlos, puede utilizar:
```
azd deploy
```

### Habilitar Dashboard de .NET Aspire para desplegarlo en Azure:
```
azd config set alpha.aspire.dashboard on
```

### Habilitar Dashboard de .NET Aspire para desplegarlo en Local:
```
azd monitor

```
### Eliminar recursos de Azure
```
az group delete --name rg-demo3
```
