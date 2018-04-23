using System;
using DevExpress.Xpo;

 
	
	public class ParentObject : XPObject {
		private ParentObject() : base() {
			// This constructor is used when an object is loaded from a persistent storage.
			// Do not place any code here.
		}

		public ParentObject(Session session) : base(session) {
			// This constructor is used when an object is loaded from a persistent storage.
			// Do not place any code here.
		}

		public override void AfterConstruction() { 
			base.AfterConstruction(); 
			// Place here your initialization code.
		}

        protected ChildObject _Child;
        [Association("Child-Parents", typeof(ParentObject))]
        public ChildObject Child
        {
            get { return _Child; }
            set { SetPropertyValue<ChildObject>("Child", ref _Child, value); }
        }

        protected String _Name;
        public String Name
        {
            get { return _Name; }
            set { SetPropertyValue<String>("Name", ref _Name, value); }
        }
	}

