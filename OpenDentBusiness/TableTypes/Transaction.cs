using Imedisoft.Data.Annotations;
using Imedisoft.Data.Models;
using System;
using System.Collections;

namespace OpenDentBusiness
{
    /// <summary>
    /// Used in the accounting section of the program. 
    /// Each row is one transaction in the ledger, and must always have at least two splits. 
    /// All splits must always add up to zero.
    /// </summary>
    [Table("transactions")]
	public class Transaction : TableBase
	{
		[PrimaryKey]
		public long Id;

		/// <summary>
		/// The date on which the transaction was entered.
		/// </summary>
		public DateTime DateAdded;

		/// <summary>
		/// The ID of the user that entered the transaction.
		/// </summary>
		[Column(ReadOnly = true), ForeignKey(typeof(User), nameof(User.Id))]
		public long UserId;

		/// <summary>
		/// Will eventually be replaced by a source document table, and deposits will just be one of many types.
		/// </summary>
		[ForeignKey(typeof(Deposit), nameof(Deposit.Id))]
		public long DepositId;

		/// <summary>
		/// Like DepositNum, it will eventually be replaced by a source document table, and payments will just be one of many types.
		/// </summary>
		[ForeignKey(typeof(Payment), nameof(Payment.PayNum))]
		public long PaymentId;

		/// <summary>
		/// The ID of the user that last modified the transaction.
		/// </summary>
		[ForeignKey(typeof(User), nameof(User.Id))]
		public long ModifiedBy;

		/// <summary>
		/// The date and time on which the transaction was last modified.
		/// </summary>
		[Column(AutoGenerated = true)]
		public DateTime ModifiedDate;
	}
}
