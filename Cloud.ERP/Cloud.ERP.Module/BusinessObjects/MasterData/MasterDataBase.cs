using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Cloud.ERP.Module.BusinessObjects.MasterData
{
    [NonPersistent]
    public class MasterDataBase : VDBaseObject
    {
        #region Members
        public const string LocalizationAlias = "Iif([<SupportTranslateText>][Language.Code = CurrentUserLanguage() and PropertyName = 'Name' and _ReferencedObject.TargetKey = ^.Oid].Max(TranslateText) is null, Name, [<SupportTranslateText>][Language.Code = CurrentUserLanguage() and PropertyName = 'Name' and _ReferencedObject.TargetKey = ^.Oid].Max(TranslateText))";

        private Lazy<string> _localizedName;

        #endregion

        #region Constructor
        public MasterDataBase(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        #endregion

        #region Properties

        [Size(20), VisibleInListView(false), VisibleInLookupListView(false)]
        public string Code
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Code), value);
        }

        [Size(255)]
        [RuleRequiredField("RuleRequiredField for MasterDataBase.Name", DefaultContexts.Save)]
        public string Name
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Name), value);
        }

        [MemberDesignTimeVisibility(false), PersistentAlias(LocalizationAlias)]
        public string LocalizedName
        {
            get
            {
                _localizedName ??= new Lazy<string>(() => EvaluateAlias()?.ToString());
                return _localizedName.Value;
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [DevExpress.Xpo.Indexed]
        public bool Inactive
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(nameof(Inactive), value);
        }

        #endregion

        #region Methods
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (this.IsNewObject)
                return;

            var references = this.Session.CollectReferencingObjects(this);
            if (references.Count > 0)
            {
                var builder = new StringBuilder();
                builder.AppendLine();
                foreach (var reference in references)
                    builder.AppendLine($"{CaptionHelper.GetClassCaption(reference.GetType().FullName)}: {reference}");

                throw new Exception(string.Format(CaptionHelper.GetLocalizedText("Texts", "CannotDeleteRecordBecauseOfReference"), builder.ToString()));
            }
        }
        #endregion
    }
}
