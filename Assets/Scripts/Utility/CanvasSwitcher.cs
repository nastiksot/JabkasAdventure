using System.Linq;
using Disablers;
using Models.ClassModels;
using TMPro;
using UnityEngine;

namespace Utility
{
    public class CanvasSwitcher : MonoBehaviour
    {
        [SerializeField] protected NamedDisabler[] tableNamedDisabler;
        [SerializeField] private TMP_Text textField;
        [SerializeField] private float delayTime;
        [SerializeField] private bool showFirstOnAwake = true;

        private void Awake()
        {
            if (!showFirstOnAwake) return;
            HideAllTables();
            if (tableNamedDisabler.Length == 0 || tableNamedDisabler[0] == null) return;
            tableNamedDisabler[0].value.DisplayObject(true);
            SetText(tableNamedDisabler[0]);
        }

        /// <summary>
        /// Showing canvas group sent thought parameter and disabling all others
        /// </summary>
        /// <param name="canvasGroup"></param>
        public void OpenTable(BaseObjectDisabler objectDisabler)
        {
            HideAllTables();
            var namedGroup = GetNamedGroup(objectDisabler);
            if (namedGroup == null) return;
            namedGroup.value.DisplayObject(true);
            SetText(namedGroup);
        }

        private void SetText(NamedDisabler namedGroup)
        {
            if (textField != null)
                textField.text = namedGroup.key;
        }

        private NamedDisabler GetNamedGroup(BaseObjectDisabler objectDisabler)
        {
            var namedGroup = tableNamedDisabler.FirstOrDefault(n => n.value.GetHashCode() == objectDisabler.GetHashCode());
            return namedGroup;
        }

        /// <summary>
        /// Showing canvas group sent thought parameter with delay and disabling all others
        /// </summary>
        /// <param name="objectDisabler"></param>
        public void DelayedOpenTable(BaseObjectDisabler objectDisabler)
        {
            HideAllTables();
            var namedGroup = GetNamedGroup(objectDisabler);
            if (namedGroup == null) return;
            SetText(namedGroup);

            StartCoroutine(namedGroup.value.DisplayObject(true, delayTime, (canvas) => { namedGroup.value = canvas; }));
        }

        public void HideAllTables()
        {
            for (int i = 0; i < tableNamedDisabler.Length; i++)
            {
                tableNamedDisabler[i].value.DisplayObject(false);
            }
        }
    }
}