﻿using Newtonsoft.Json.Linq;

namespace KenticoCloud.Delivery
{
    /// <summary>
    /// Represents a response from Kentico Cloud Delivery API that contains an content items.
    /// </summary>
    /// <typeparam name="T">Generic strong type of item representation.</typeparam>
    public sealed class DeliveryItemResponse<T> : AbstractResponse
    {
        private readonly JToken _response;
        private readonly ICodeFirstModelProvider _codeFirstModelProvider;
        private dynamic _linkedItems;
        private T _item;

        /// <summary>
        /// Gets a content item.
        /// </summary>
        public T Item
        {
            get
            {
                if (_item == null)
                {
                    _item = _codeFirstModelProvider.GetContentItemModel<T>(_response["item"], _response["modular_content"]);
                }
                return _item;
            }
        }

        /// <summary>
        /// Gets the dynamic view of the JSON response where linked items and their properties can be retrieved by name, for example <c>LinkedItems.about_us.elements.description.value</c>.
        /// </summary>
        public dynamic LinkedItems
        {
            get { return _linkedItems ?? (_linkedItems = JObject.Parse(_response["modular_content"].ToString())); }
        }

        internal DeliveryItemResponse(JToken response, ICodeFirstModelProvider codeFirstModelProvider, string apiUrl) : base(apiUrl)
        {
            _response = response;
            _codeFirstModelProvider = codeFirstModelProvider;
        }
    }
}
