<!-- default file list -->
*Files to look at*:

* [ChildObject.cs](./CS/WebSite/App_Code/ChildObject.cs) (VB: [ChildObject.vb](./VB/WebSite/App_Code/ChildObject.vb))
* [ParentObject.cs](./CS/WebSite/App_Code/ParentObject.cs) (VB: [ParentObject.vb](./VB/WebSite/App_Code/ParentObject.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [Global.asax](./CS/WebSite/Global.asax) (VB: [Global.asax](./VB/WebSite/Global.asax))
<!-- default file list end -->
# How to implement a custom TypeConverter class for an XPO object


<p>The ASPxGridView caches object properties, if they are used in data-binding expressions. However, if you use XPO or custom objects that use a referenced association, the ASPxGridView tries to cache references too. Unfortunately, the caching operation (similar to the ToString method) is performed smoothly, but the object restoration from cache (from String to object) could be raised with an exception:</p><p><i>TypeConverter cannot convert from System.String.</i></p><p>A solution is to turn off the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_EnableRowsCachetopic">ASPxGridView.EnableRowsCache</a> property. This solution is acceptable when the page doesn't have several grids, and in most cases doesn't affect page performance too much.</p><p>However you can implement a custom TypeConverter derived class, that can convert from the String type correctly.</p><p>By the way, it isn't recommended to serialize objects often, because serialized objects take much space, and the page size might become big (e.g. more than 1 mb).</p><p><strong>See Also:</strong><br />
<a href="http://msdn.microsoft.com/en-us/library/ayybcxe5.aspx">How to: Implement a Type Converter</a><br />
<a href="http://www.codeproject.com/KB/dotnet/BasicPropertyGrid.aspx">Introduction to the TypeConverter</a></p>


<h3>Description</h3>

<p>The ParentObject has an association with the ChildObject. The ASPxGridView uses a data-binding expression in the EditForm template:</p><code lang='aspx'>
&lt;%# Eval("Child!.ChildName") %&gt;
</code><p>Because of it, the ASPxGridView tries to cache the entire Child (ChildObject) object.<br />
The ChildObjectTypeConverter converts the ChildObject to the String (stores a key only). When a conversation from the String occurs, the converter uses the key value to retrieve this object from the XPO.</p><p>This implementation doesn&#39;t allow avoiding odd bindings, but helps keep the caching option enabled.</p>

<br/>


