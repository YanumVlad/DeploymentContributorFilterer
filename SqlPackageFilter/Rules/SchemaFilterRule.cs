using System.Linq;
using AgileSqlClub.SqlPackageFilter.DacExtensions;
using AgileSqlClub.SqlPackageFilter.Filter;
using Microsoft.SqlServer.Dac.Model;

namespace AgileSqlClub.SqlPackageFilter.Rules
{
    public class SchemaFilterRule : FilterRule
    {
        public SchemaFilterRule(FilterOperation operation, string match, MatchType matchType) : base(operation, match, matchType)
        {
        }

        public override bool Matches(ObjectIdentifier name, ModelTypeClass type)
        {
            var schemaName = type == ModelSchema.Schema ? name.Parts.Last() : name.GetSchemaName();
            
            if (string.IsNullOrEmpty(schemaName))
                return false;

            return Matches(schemaName);
        }
    }
}