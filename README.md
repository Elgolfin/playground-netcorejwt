# About ASP.NET Core Authentication

## Useful Reading

* [Token Authentication in ASP.NET Core 2.0 - A Complete Guide](https://developer.okta.com/blog/2018/03/23/token-authentication-aspnetcore-complete-guide)
* [Use cookie authentication without ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.2)
* [Bearer Token Authentication in ASP.NET Core](https://blogs.msdn.microsoft.com/webdev/2016/10/27/bearer-token-authentication-in-asp-net-core/)

## Setup the project with auth0

* Create the ***secrets.json*** file in your home folder ***~/.microsoft/usersecrets/playground-netcorejwt/secrets.json*** (you can copy and paste the ***appsettings.json*** file)
* Replace the ***issuer*** value with your auth0 URL (i.e. [***https://{your_tenant}.auth0.com/***](https://{your_tenant}.auth0.com/))
* Replace the ***audience*** value with your auth0 audience key (i.e. ***VcKdHxSHmsuWAIMrH5Rwaing816B7zjt***)

## Configure HTTPS in the local dev environment

1. Install [mkcert](https://github.com/FiloSottile/mkcert)
2. Generate the local CA certificate

   ```bash
    $(go env GOPATH)/bin/mkcert -install
   ```
3. Create the .pfx certificate:

   ```bash
   $(go env GOPATH)/bin/mkcert localhost 127.0.0.1 ::1
   openssl pkcs12 -export -in ~/localhost+2.pem -inkey ~/localhost+2-key.pem -out localhost+2.pfx
   ```

4. Add the following section to the ***~/.microsoft/usersecrets/playground-netcorejwt/secrets.json*** file:

```json
"Kestrel": {
    "EndPoints": {
      "Https": {
        "Url": "https://*:5001",
        "Certificate": {
          "Path": "/home/user/localhost.pfx",
          "Password": "{password}"
        }
      }
    }
  }
```

## API Routes

* GET /api/values (no Bearer token is needed)
* GET /api/protected (a Bearer token is needed)