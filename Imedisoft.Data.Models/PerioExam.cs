using Imedisoft.Data.Annotations;
using System;

namespace Imedisoft.Data.Models
{
    [Table("perio_exams")]
	public class PerioExam
	{
		[PrimaryKey]
		public long Id;

		public long PatientId;

		public DateTime ExamDate;

		[ForeignKey(typeof(Provider), nameof(Provider.Id))]
		public long ProviderId;

		[Column(AutoGenerated = true)]
		public DateTime LastModifiedDate;
	}
}
