{
    "$schema": "http://json.schemastore.org/launchsettings.json",
        "iisSettings": {
        "windowsAuthentication": false,
            "anonymousAuthentication": true,
                "iisExpress": {
            "applicationUrl": "http://localhost:19940",
                "sslPort": 44329
        }
    },
    "profiles": {
        "IIS Express": {
            "commandName": "IISExpress",
                "launchBrowser": true,
                    "launchUrl": "swagger",
                        "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            }
        },
        "PontiApp.EventPlace.Api": {
            "commandName": "Project",
                "launchBrowser": true,
                    "launchUrl": "swagger",
                        "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            },
            "applicationUrl": "https://localhost:5001;http://localhost:5000",
                "dotnetRunMessages": "true"
        },
        "Docker": {
            "commandName": "Docker",
                "launchBrowser": true,
                    "launchUrl": "{Scheme}://{ServiceHost}:{ServicePort}/swagger",
                        "publishAllPorts": true,
                            "useSSL": true
        }
    }
}