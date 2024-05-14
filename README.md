# Loqate

HTTPS client for [Loqate](https://loqate.com) address lookup and location services.

The NuGet package is available from [nuget.org](https://nuget.org/packages/Loqate).

Install using `Install-Package Loqate'.

> Disclaimer.  I am not affiliated with Loqate GBG and am just providing this library out of courtesy.

## Usage

APIs use a fluent builder pattern to construct the request.  Calling `GetResponse()` sends
the request to the server.

Use as follows:

```c#
Loqate.Configure("BLAH-BLAH-BLAH-BLAH");

try{
    var response = Loqate
        .Find("My House")
        .Container("GBR|EFG|123522|ENG")
        .GetResponse();

    var address = Loqate.Retrieve("GBR|ABC|12345|ENG").GetResponse();
}
catch (LoqateException ex)
{
    //Error response information is found
    // in LoqateException
}
```

Errors in the response are thrown via a `LoqateException` so be sure to catch these.

Possible error codes can be found on the [Loqate documentation website](https://www.loqate.com/developers/api/).

## Version history

### v8.1
  - Breaking change where the `Loqate` class uses the singleton pattern.
  - Adds GeoLocation API.
  - Fixed issues with retrieve API.

### v8.0
First build.  Find and Retrieve endpoints.

## Roadmap

The objective is to incorporate all the Loqate services for easy 
integration with dotnet projects via a 'Loqate' NuGet package.
