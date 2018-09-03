## Summary

This is a group of demo apps that were built with Visual Studio Code and .NET Core. The demo shows an example of an API. The API can be hosted and accessed by any device or application that has access to it. There are also examples for unit testing an API and calling an API from a client application.

## MessageApi

Demo API that will write and read content from a database or other sources. The hosted API can be accessed from any application or device.

The project shows examples of inheritance with the message models. There is a base message model that is inherited by unique models for file and database related data. 

There is also an interface for messages. For example, a message class will be able to read and write content. There can be message classes that require unique logic. For example, a database message class will be able to write data to a database. A file message class would be able to write data to a local file.

There is an appsettings.json file that can be used to store database connection strings and other app settings.

## MessageConsole

Demo app that demonstrates how a client can connect to the API. There is a demo API in the MessageApi project. It simply returns “Hello World”. The console app will write the results to the console screen.

There is an appsettings.json file that is used to set the API url.

## MessageApi.Test

Demo app for unit testing the MessageApi project. Unit tests can run to determine if methods/ functions are working properly. There is an example test that calls one of the MessageApi project’s API’s.
