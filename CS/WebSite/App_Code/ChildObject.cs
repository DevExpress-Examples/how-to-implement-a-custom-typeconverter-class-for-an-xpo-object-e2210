using System;
using DevExpress.Xpo;
using System.ComponentModel;

[TypeConverter(typeof(ChildObjectTypeConverter))]
public class ChildObject : XPObject {
    public ChildObject()
        : base() {
        // This constructor is used when an object is loaded from a persistent storage.
        // Do not place any code here.
    }

    public ChildObject(Session session)
        : base(session) {
        // This constructor is used when an object is loaded from a persistent storage.
        // Do not place any code here.
    }

    public override void AfterConstruction() {
        base.AfterConstruction();
        // Place here your initialization code.
    }

    protected String _ChildName;
    public String ChildName {
        get { return _ChildName; }
        set { SetPropertyValue<String>("ChildName", ref _ChildName, value); }
    }

    [Association("Child-Parents", typeof(ParentObject))]
    public XPCollection<ParentObject> Parents {
        get { return GetCollection<ParentObject>("Parents"); }
    }

}

/*
 * Resources:
 * http://www.codeproject.com/KB/dotnet/BasicPropertyGrid.aspx
 * http://msdn.microsoft.com/en-us/library/ayybcxe5.aspx
 * 
 * ChildObjectTypeConverter:
 * Converts the ChildObject to String: store Oid;
 * Converts the ChildObject from String: get the object from the Session;
 */

public class ChildObjectTypeConverter : TypeConverter {
    public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
        if (sourceType == typeof(String))
            return true;

        return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
        if (value is String) {
            Session session = new Session();
            ChildObject child = session.GetObjectByKey<ChildObject>(Convert.ToInt32(value));
         
            return child;
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override Object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value, Type destinationType) {
        if (destinationType == typeof(String)) {
            ChildObject childObject = (ChildObject)value;
           
            return childObject.Oid.ToString();
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}