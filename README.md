# WalmartProductViewer

### Made with C# using the .NET Framework MVC . Client-side search filters, and product detail page were implemented.

### The Walmart API is generally pretty slow, what are some optimizations that could be implemented to improve the user experience?
You could cache the response both server side and client side (with non-store option), and have the back-end update it every few minutes.  
You could sign up for multiple API keys and make concurrent calls to load the products page faster.

### If pagination on the products page was not implemented, how would you implement?
Have a while loop that continually makes GET requests on the next page and add it to a temporary data structure. Then proceed to apply a pagination algorithm
that would render the data structure into seperate pages.

### Any improvements you would make to your application?
I would test it more and improve the error handling, improve aesthetics, add more comments, add more logger classes to help with debugging. 
