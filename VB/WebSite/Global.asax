<%@ Application Language="vb" %>
<script RunAt="server">

	Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs on application startup
		Dim ds As New DevExpress.Xpo.DB.InMemoryDataStore()

		Dim dict As DevExpress.Xpo.Metadata.XPDictionary = New DevExpress.Xpo.Metadata.ReflectionDictionary()
		dict.GetDataStoreSchema(GetType(ParentObject).Assembly)

		DevExpress.Xpo.XpoDefault.DataLayer = New DevExpress.Xpo.ThreadSafeDataLayer(dict, ds)
		DevExpress.Xpo.XpoDefault.Session = Nothing

		CreateObjects()
	End Sub

	Sub CreateObjects()
		Using uow As New DevExpress.Xpo.UnitOfWork()
			Dim child As New ChildObject(uow)
			child.ChildName = "Child1"

			Dim parent As New ParentObject(uow)
			parent.Name = "Parent1"
			parent.Child = child

			uow.CommitChanges()
		End Using
	End Sub

	Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
		'  Code that runs on application shutdown

	End Sub

	Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when an unhandled error occurs

	End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a new session is started

	End Sub

	Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a session ends. 
		' Note: The Session_End event is raised only when the sessionstate mode
		' is set to InProc in the Web.config file. If session mode is set to StateServer 
		' or SQLServer, the event is not raised.

	End Sub

</script>
