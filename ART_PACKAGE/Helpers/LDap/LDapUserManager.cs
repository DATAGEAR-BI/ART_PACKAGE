using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            this.LDAPHost = config.GetSection("LdapAuth:host").Value;
            this.LDAPPort = int.Parse(config.GetSection("LdapAuth:port").Value);
            this.LogedInOn = config.GetSection("LdapAuth:binduser").Value;
            this.LogedInPassword = config.GetSection("LdapAuth:binduserpassword").Value;
            this.SearchPase = config.GetSection("LdapAuth:searchBase").Value;
            this.SearchFilter = config.GetSection("LdapAuth:filter").Value;
            _logger = logger;
        }

        public UserLoginInfo? Authnticate(string uid, string password)
        {
            LdapConnection conn = new LdapConnection();
            try
            {
                var searchFilter = string.Format(SearchFilter, uid);
                string[] requiredAttr = { "sAMAccountName" };

                conn.Connect(LDAPHost, LDAPPort);
                if (!conn.Connected)
                    return null;
                LdapSearchResults lsr = (LdapSearchResults)conn.Search(SearchPase,
                                                    LdapConnection.SCOPE_BASE,
                                                    searchFilter,
                                                    requiredAttr,
                                                    false);
                try
                {
                    conn.Bind(LogedInOn, LogedInPassword);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Couldn't bind to the Admin user due to invalid creds --------- {ex.Message}");
                }

                try
                {
                    var user = lsr.next();
                    if (user == null) return null;
                    var userToconnect = user.DN;
                    try
                    {
                        conn.Bind(userToconnect, password);
                        if (conn.Bound) return new UserLoginInfo("LDap", uid, "LDap");
                        else return null;
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
