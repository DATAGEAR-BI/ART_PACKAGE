using Microsoft.AspNetCore.Identity;
using Novell.Directory.Ldap;

namespace ART_PACKAGE.Helpers.LDap
{
    public class LDapUserManager
    {
        private readonly string LDAPHost;
        private readonly int LDAPPort;
        private readonly string LogedInOn;

        private readonly string LogedInPassword;

        private readonly string SearchPase;

        private readonly string SearchFilter;
        private readonly ILogger<LDapUserManager> _logger;

        public LDapUserManager(IConfiguration config, ILogger<LDapUserManager> logger)
        {

            LDAPHost = config.GetSection("LdapAuth:host").Value;
            LDAPPort = int.Parse(config.GetSection("LdapAuth:port").Value);
            LogedInOn = config.GetSection("LdapAuth:binduser").Value;
            LogedInPassword = config.GetSection("LdapAuth:binduserpassword").Value;
            SearchPase = config.GetSection("LdapAuth:searchBase").Value;
            SearchFilter = config.GetSection("LdapAuth:filter").Value;
            _logger = logger;
        }

        public UserLoginInfo? Authnticate(string uid, string password)
        {
            LdapConnection conn = new();
            try
            {
                string searchFilter = string.Format(SearchFilter, uid);
                string[] requiredAttr = { "sAMAccountName" };

                conn.Connect(LDAPHost, LDAPPort);
                if (!conn.Connected)
                {
                    return null;
                }
                _logger.LogWarning("ldap connected {con}", conn.Connected);

                LdapSearchResults lsr = conn.Search(SearchPase,
                                                    LdapConnection.SCOPE_SUB,
                                                    searchFilter,
                                                    requiredAttr,
                                                    false);
                try
                {
                    conn.Bind(LogedInOn, LogedInPassword);
                    _logger.LogWarning("ldap bounded {con}", conn.Bound);

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Couldn't bind to the Admin user due to invalid creds --------- {ex.Message}");
                }

                try
                {
                    LdapEntry user = lsr.next();
                    if (user == null)
                    {
                        return null;
                    }
                    _logger.LogWarning("before user DN");
                    string userToconnect = user.DN;
                    _logger.LogWarning("user DN {user}", userToconnect);
                    try
                    {
                        conn.Bind(userToconnect, password);
                        return conn.Bound ? new UserLoginInfo("LDap", uid, "LDap") : null;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"invalid login creds --------- {ex.Message}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"LDap Search Error --------- {ex.Message}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't connect to the server --------- {ex.Message}");
                return null;
            }

        }
    }
}
