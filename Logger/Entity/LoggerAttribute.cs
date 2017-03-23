using System;

namespace Logger
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LoggerAttribute : Attribute
    {
        public LoggerAttribute()
        {
            Category = Category.Default;
        }

        public LoggerAttribute(Category category)
        {
            Category = category;
        }

        public Category Category { get; set; }
        public string Name { get; set; }
    }
}
