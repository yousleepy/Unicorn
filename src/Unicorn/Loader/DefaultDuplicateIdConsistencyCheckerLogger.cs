﻿using Rainbow.Model;
using Sitecore.StringExtensions;
using Unicorn.Data;
using Unicorn.Logging;

namespace Unicorn.Loader
{
	public class DefaultDuplicateIdConsistencyCheckerLogger : IDuplicateIdConsistencyCheckerLogger
	{
		private readonly ILogger _logger;

		public DefaultDuplicateIdConsistencyCheckerLogger(ILogger logger)
		{
			_logger = logger;
		}

		public virtual void DuplicateFound(IItemData existingItemData, IItemData duplicateItemData)
		{
			_logger.Error("Duplicate serialized item IDs were detected ({0}) - this usually indicates corruption in the serialization provider data.<br>Item 1: {1}<br> Item 1 ProviderId: {2}<br>Item 2: {3}<br>Item 2 ProviderId: {4}".FormatWith(existingItemData.Id, existingItemData.GetDisplayIdentifier(), existingItemData.SerializedItemId, duplicateItemData.GetDisplayIdentifier(), duplicateItemData.SerializedItemId));
		}
	}
}
