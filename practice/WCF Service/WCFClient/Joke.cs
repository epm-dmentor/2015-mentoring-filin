using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WCFClient
{
    public class Joke : object, IExtensibleDataObject, INotifyPropertyChanged
    {
        [OptionalField] private string TypeField;

        [OptionalField] private JokeService.Value[] ValueField;
        [NonSerialized] private ExtensionDataObject extensionDataField;

        [DataMember]
        public string Type
        {
            get { return TypeField; }
            set
            {
                if ((ReferenceEquals(TypeField, value) != true))
                {
                    TypeField = value;
                    RaisePropertyChanged("Type");
                }
            }
        }

        [DataMember]
        public JokeService.Value[] Value
        {
            get { return ValueField; }
            set
            {
                if ((ReferenceEquals(ValueField, value) != true))
                {
                    ValueField = value;
                    RaisePropertyChanged("Value");
                }
            }
        }

        [Browsable(false)]
        public ExtensionDataObject ExtensionData
        {
            get { return extensionDataField; }
            set { extensionDataField = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Value : object, IExtensibleDataObject, INotifyPropertyChanged
    {
        [OptionalField] private string[] CategoriesField;

        [OptionalField] private int IdField;

        [OptionalField] private string JokeField;
        [NonSerialized] private ExtensionDataObject extensionDataField;

        [DataMember]
        public string[] Categories
        {
            get { return CategoriesField; }
            set
            {
                if ((ReferenceEquals(CategoriesField, value) != true))
                {
                    CategoriesField = value;
                    RaisePropertyChanged("Categories");
                }
            }
        }

        [DataMember]
        public int Id
        {
            get { return IdField; }
            set
            {
                if ((IdField.Equals(value) != true))
                {
                    IdField = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        [DataMember]
        public string Joke
        {
            get { return JokeField; }
            set
            {
                if ((ReferenceEquals(JokeField, value) != true))
                {
                    JokeField = value;
                    RaisePropertyChanged("Joke");
                }
            }
        }

        [Browsable(false)]
        public ExtensionDataObject ExtensionData
        {
            get { return extensionDataField; }
            set { extensionDataField = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}