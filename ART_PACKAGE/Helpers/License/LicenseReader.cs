using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Data.Constants;
using java.security;
using java.security.spec;
using javax.crypto;
using System.Text;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.License
{
    public class LicenseReader : ILicenseReader
    {
        private readonly Cipher _cipher;
        private readonly PublicKey _publicKey;
        private readonly ILogger<LicenseReader> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LicenseReader(ILogger<LicenseReader> logger, IWebHostEnvironment webHostEnvironment)
        {
            _cipher = Cipher.getInstance("RSA");
            _publicKey = getDecodedPublicKey(LicenseConstants.PUBLIC_KEY);
            _cipher.init(2, _publicKey);
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        public Middlewares.License.License ReadFromPath(string path)
        {
            string appPath = _webHostEnvironment.ContentRootPath;
            string licPath = Path.Combine(appPath, Path.Combine("Licenses", path));
            try
            {
                string licEncodedString = File.ReadAllText(licPath);
                return ReadFromText(licEncodedString);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }


        }

        public Middlewares.License.License ReadFromText(string encodedtext)
        {
            return Parse(DycreptLicense(encodedtext));
        }
        private byte[] DycreptLicense(string licenseEncoded)
        {
            byte[] encrypted = Convert.FromBase64String(licenseEncoded);
            byte[] original = _cipher.doFinal(encrypted);
            return original;
        }
        private Middlewares.License.License Parse(byte[] data)
        {
            Middlewares.License.License license = new();

            byte[] timeBytes = data[..8];
            long timeValue = 0L;
            foreach (byte @byte in timeBytes)
            {
                timeValue = (timeValue << 8) + (@byte & 255);
            }
            license.ValidUnti = timeValue;
            byte[] client = data[12..];
            license.Client = Encoding.UTF8.GetString(client);
            return license;
        }

        private PublicKey getDecodedPublicKey(string encoded)
        {
            try
            {
                X509EncodedKeySpec x509EncodedKeySpec = new(Convert.FromBase64String(encoded));
                PublicKey publicKey = KeyFactory.getInstance("RSA").generatePublic(x509EncodedKeySpec);
                return publicKey;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public IEnumerable<Middlewares.License.License> ReadAllAppLicenses()
        {
            string[] licensesFiles = Directory
              .GetFiles(Path.Combine(_webHostEnvironment.ContentRootPath, "Licenses"));
            IEnumerable<string> licenseFilesNames = licensesFiles.Select(x => x.Replace(Path.Combine(_webHostEnvironment.ContentRootPath, "Licenses") + "\\", ""));
            IEnumerable<Middlewares.License.License> licenses = licenseFilesNames.Select(x => ReadFromPath(x));
            return licenses;
        }

        public GridResult<Middlewares.License.License> GetGridData(GridRequest request, Expression<Func<Middlewares.License.License, bool>>? baseCondition = null, SortOption? defaultSort = null,
            IEnumerable<Expression<Func<Middlewares.License.License, object>>>? includes = null)
        {

            IQueryable<Middlewares.License.License> data = ReadAllAppLicenses().AsQueryable();
            if (includes is not null)
            {
                foreach (Expression<Func<Middlewares.License.License, object>> inculde in includes)
                {
                    data = data.Include(inculde);
                }
            }

            if (baseCondition is not null)
            {
                data = data.Where(baseCondition);
            }
            Expression<Func<Middlewares.License.License, bool>> ex = request.Filter.ToExpression<Middlewares.License.License>();

            data = data.Where(ex);
            if (!request.All)
            {
                ParameterExpression parameter = Expression.Parameter(typeof(Middlewares.License.License), "item");
                MemberExpression property = Expression.Property(parameter, request.IdColumn);
                IEnumerable<ConstantExpression> constantValues = request.SelectedValues.Select(value => Expression.Constant(Convert.ChangeType(value, property.Type)));

                System.Reflection.MethodInfo containsMethod = typeof(Enumerable)
                    .GetMethods()
                    .Where(method => method.Name == "Contains")
                    .Single(method => method.GetParameters().Length == 2)
                    .MakeGenericMethod(property.Type);

                MethodCallExpression containsExpression = Expression.Call(
                    containsMethod,
                    Expression.Constant(request.SelectedValues),
                    property
                );

                Expression<Func<Middlewares.License.License, bool>> predicate = Expression.Lambda<Func<Middlewares.License.License, bool>>(containsExpression, parameter);
                data = data.Where(predicate);
            }
            int count = data.Count();


            if (request.Sort is not null && request.Sort.Any())
            {
                SortOption firtsOption = request.Sort[0];
                Expression<Func<Middlewares.License.License, object>> sortEx = firtsOption.GetSortExpression<Middlewares.License.License>();

                IOrderedQueryable<Middlewares.License.License>? sortedData = firtsOption.dir.ToLower().Contains("asc") ? data.OrderBy(sortEx) : data.OrderByDescending(sortEx);
                foreach (SortOption? item in request.Sort.Skip(1))
                {
                    sortEx = item.GetSortExpression<Middlewares.License.License>();
                    sortedData = item.dir.ToLower().Contains("asc") ? sortedData.ThenBy(sortEx) : sortedData.ThenByDescending(sortEx);
                }
                data = sortedData;
            }
            else
            {
                if (defaultSort != null)
                {
                    Expression<Func<Middlewares.License.License, object>> sortEx = defaultSort.GetSortExpression<Middlewares.License.License>();
                    data = defaultSort.dir.ToLower().Contains("asc") ? data.OrderBy(sortEx) : data.OrderByDescending(sortEx);
                }
            }
            if (request.Skip != 0)
                data = data.Skip(request.Skip);


            if (request.Take < count)
                data = data.Take(request.Take);


            return new GridResult<Middlewares.License.License>
            {
                data = data,
                total = count,
            };
        }

        public IQueryable<Middlewares.License.License> GetScheduleData(List<object> @params)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Middlewares.License.License> ExcueteProc(List<BuilderFilter> QueryBuilderFilters)
        {
            throw new NotImplementedException();
        }

        public bool BulkInsert(IEnumerable<Middlewares.License.License> data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Middlewares.License.License> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Middlewares.License.License> GetByCondition(Expression<Func<Middlewares.License.License, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Middlewares.License.License? GetFirstWithCondition(Expression<Func<Middlewares.License.License, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object?> GetDistinctValuesOf(Expression<Func<Middlewares.License.License, object>> propertySelector, Expression<Func<Middlewares.License.License, bool>>? condition = null)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
