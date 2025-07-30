using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Package
{
    public class GetStaticDetailValuesListResDto
    {
        [Column("parameter_code")]
        public int ParameterCode { get; set; }

        [Column("value_1")]
        public string Value1 { get; set; }

        [Column("value_2")]
        public string Value2 { get; set; }

        [Column("value_3")]
        public string Value3 { get; set; }

        [Column("value_4")]
        public string Value4 { get; set; }

        [Column("value_5")]
        public string Value5 { get; set; }

        [Column("value_6")]
        public string Value6 { get; set; }

        [Column("value_7")]
        public string Value7 { get; set; }

        [Column("value_8")]
        public string Value8 { get; set; }

        [Column("value_9")]
        public string Value9 { get; set; }

        [Column("value_10")]
        public string Value10 { get; set; }
    }
}
