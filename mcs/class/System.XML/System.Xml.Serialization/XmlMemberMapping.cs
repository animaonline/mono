// 
// System.Xml.Serialization.XmlMemberMapping
//
// Author:
//   Tim Coleman (tim@timcoleman.com)
//   Lluis Sanchez Gual (lluis@ximian.com)
//
// Copyright (C) Tim Coleman, 2002
//

namespace System.Xml.Serialization 
{
	public class XmlMemberMapping {

		XmlTypeMapMember _mapMember;
		string _elementName;
		string _memberName;
		string _namespace;
		string _typeNamespace;

		internal XmlMemberMapping (string memberName, string defaultNamespace, XmlTypeMapMember mapMem, bool encodedFormat)
		{
			_mapMember = mapMem;
			_memberName = memberName;

			if (mapMem is XmlTypeMapMemberElement)
			{
				XmlTypeMapElementInfo info = (XmlTypeMapElementInfo) ((XmlTypeMapMemberElement)mapMem).ElementInfo[0];
				_elementName = info.ElementName;
				if (encodedFormat)
				{
					_namespace = defaultNamespace;
					if (info.MappedType != null) _typeNamespace = "";
					else _typeNamespace = info.DataTypeNamespace;
				}
				else
				{
					_namespace = info.Namespace;
					if (info.MappedType != null) _typeNamespace = info.MappedType.Namespace;
					else _typeNamespace = "";
				}
			}
			else
			{
				_elementName = _memberName;
				_namespace = "";
			}
		}

		#region Properties

		public bool Any {
			get { return _mapMember is XmlTypeMapMemberAnyElement; }
		}

		public string ElementName {	
			get { return _elementName; }
		}

		public string MemberName {	
			get { return _memberName; }
		}

		public string Namespace {
			get { return _namespace; }
		}

		public string TypeFullName {
			get { return _mapMember.TypeData.FullTypeName; }
		}

		public string TypeName {
			get { return _mapMember.TypeData.XmlType; }
		}

		public string TypeNamespace {
			get { return _typeNamespace; }
		}

		internal XmlTypeMapMember TypeMapMember {
			get { return _mapMember; }
		}

		#endregion // Properties
	}
}
