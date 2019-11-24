using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            :base(options)
        { }

        public DbSet<Result> RootObjects { get; set; }
    }
    public class Results
    {
        public int skip { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class Meta
    {
        public string disclaimer { get; set; }
        public string terms { get; set; }
        public string license { get; set; }
        public string last_updated { get; set; }
        public Results results { get; set; }
    }

    public class Openfda
    {
    }

    public class Result
    {
        public string country { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string city { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string reason_for_recall { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string address_1 { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string address_2 { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string code_info { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string product_quantity { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string center_classification_date { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string distribution_pattern { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string state { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string product_description { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string report_date { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string classification { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string openfda { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string recall_number { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string recalling_firm { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string initial_firm_notification { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string event_id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string product_type { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string termination_date { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string more_code_info { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string recall_initiation_date { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string postal_code { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string voluntary_mandated { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string status { get; set; }

    }

    public class RootObject
    {
        public Meta meta { get; set; }
        public List<Result> results { get; set; }
    }
}