==============================================================
QUESTIONS
--------------------------------------------------------------
~ Token management approach (JWT / OAuth)

==============================================================
Objectives
--------------------------------------------------------------
- Offer flexible integration methods options
- Create easy to use API's/Services
- Maximize re-use, no duplication only different representations
- Future proof, extendable without breaking existing integrations (Open Close)
- Auto Documentation (Little to no work maintaining documentation on changes)
- Testability

==============================================================
General Considerations
--------------------------------------------------------------
~ Provide ToString() properties for Enum's (Shared DTO's but for REST)
~ Open close contract design
~ Avoid Nullable parameters or any funny C# coolnes in DTO's for Java Consumers

==============================================================
Common
--------------------------------------------------------------
[X] Delegate pass through to both Web Services and REST API
[X] Versioned services (Future extendability or re-use)
[O] Separate Service Accounts Types (Only used through API's) 
[X] Echo test operations on all services and resources
[O] V0 - Stubbed Results (Optional)

==============================================================-
Web API
--------------------------------------------------------------
[X] Basic Authentication
[X] Centralized Error Handling (Including appropriate HTTP codes)

Developer Portal
----------------
|[X] Help Page (https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages)
|[X] Swagger Live Documentation (
	 ~ Include: XML documentation re-use from Help Page, method descriptions and security identification
|[X] POSTMAN Test Cases
|[O] Consumer SDK (.NET / Java)

==============================================================
SOAPUI
--------------------------------------------------------------
[X] Provide default namespace (No tempuri!)
[O] Centralized Error Handling
[X] Basic Authentication
[O] Consumer SDK (.NET / Java)

Developer Portal
----------------
|[X] Live Documentation (https://github.com/dotnet/docfx)
|[X] SOAPUI Test Cases
|[O] Consumer SDK (.NET / Java)

 

