# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET 8 client library for the FourTwenty LokoMerchant API, distributed as a NuGet package. The library provides OAuth 2.0 authentication and access to merchant operations for the Loko delivery platform.

## Development Commands

### Build and Package
```bash
# Build the solution
dotnet build FourTwenty.LokoMerchant.Client.sln

# Build the project
dotnet build FourTwenty.LokoMerchant.Client/FourTwenty.LokoMerchant.Client.csproj

# Create NuGet package
dotnet pack FourTwenty.LokoMerchant.Client/FourTwenty.LokoMerchant.Client.csproj

# Restore dependencies
dotnet restore
```

### Testing and Development
```bash
# Run from solution root
dotnet build
dotnet test

# Run specific test project
dotnet test FourTwenty.LokoMerchant.Client.Tests

# Run with verbose output
dotnet test --verbosity normal

# Run from project directory
cd FourTwenty.LokoMerchant.Client
dotnet build
```

## Architecture

The library follows a provider-based architecture with these core components:

### Main Client Interface
- `ILokoMerchantClient`: Primary interface providing access to all API functionality through specialized providers
- `LokoMerchantClient`: Default implementation that creates provider instances

### Service Providers
Located in `/Providers/`, each provider handles a specific domain:
- `StoreProvider`: Store operations (status, scheduling)
- `WebhooksProvider`: Webhook management and events
- `MenuProvider`: Menu items, products, offers, categories
- `OrdersProvider`: Order management and operations

### Authentication System
Located in `/Authorization/` and `/Identity/`:
- `LokoAuthorizationHandler`: HTTP message handler for automatic token management
- `BearerTokenProvider`: OAuth 2.0 token acquisition and caching
- `ILokoMerchantIdentityClient`: Identity server client for authentication

### Configuration
- `LokoMerchantConfig`: Configuration record with OAuth credentials and endpoint URLs
- Default endpoints point to production (silpo.ua), can be overridden for QA/dev environments

### Dependency Injection Setup
The `ServiceCollectionExtensions` class provides multiple registration methods:
- `AddLokoMerchantClient()`: Full client with automatic DI configuration
- `AddLokoMerchantClient(identityUrl, apiUrl)`: Custom endpoints
- `AddLokoMerchantIdentityClient()`: Identity client only

## Global Usings

The project uses global usings defined in `GlobalUsings.cs` for common types:
- System.Text.Json serialization
- HTTP client types
- All internal models, interfaces, and helpers

## Environment Configuration

### Production URLs (default)
- Identity: `https://auth.silpo.ua/`
- API: `https://merchant-api.silpo.ua/`

### QA/Testing URLs
- Identity: `https://identity-public-qa.foodtech.team/`
- API: `https://global-api-qa.foodtech.team/public/merchant`

## Testing

The test project `FourTwenty.LokoMerchant.Client.Tests` uses NUnit and includes:

### Test Categories
- **Configuration Tests**: Verify `LokoMerchantConfig` defaults and validation
- **Dependency Injection Tests**: Ensure proper service registration via extensions
- **Client Tests**: Validate provider instantiation and basic functionality

### Test Structure
- **Unit Tests**: Test individual components in isolation (no API calls)
- **Integration Tests**: Test service registration and dependency resolution
- **Mock-friendly**: Ready for HTTP client mocking with Moq

### Testing Best Practices Used
- No real API credentials required for basic tests
- Global usings for clean test files
- Proper setup/teardown with `[SetUp]` and `[TearDown]`
- Descriptive test names following pattern: `Method_Scenario_ExpectedResult`

## Package Information

- Target Framework: .NET 8.0
- Package ID: `FourTwenty.LokoMerchant.Client`
- Dependencies: Microsoft.Extensions.* packages for DI and HTTP client factory