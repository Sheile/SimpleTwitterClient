using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using OAuth;
using System.Xml.Serialization;
using System.IO;

namespace TwitterClient
{
    public class Twitter
    {
        private TwitterToken token = new TwitterToken();
        private OAuthBase oauthbase = new OAuthBase();
        const string REQUEST_TOKEN_URL = "https://twitter.com/oauth/request_token";
        const string AUTHORIZE_TOKEN_URL = "https://twitter.com/oauth/authorize";
        const string ACCESS_TOKEN_URL = "https://twitter.com/oauth/access_token";

        public Twitter(TwitterToken token)
        {
            this.token = token;
        }

        public Twitter(string consumerKey, string consumerSecret)
        {
            token.consumerKey = consumerKey;
            token.consumerSecret = consumerSecret;
        }

        static public Twitter Load(string filepath)
        {
            if (!File.Exists(filepath)) return null;

            try
            {
                FileStream stream = new FileStream(filepath, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(TwitterToken));
                Twitter twitter = new Twitter((TwitterToken)serializer.Deserialize(stream));
                stream.Close();
                return twitter;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void Save(string filepath)
        {
            FileStream stream = new FileStream(filepath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(TwitterToken));
            serializer.Serialize(stream, token);
            stream.Close();
        }


        public string GetRequestUrl()
        {
            string url;
            string queryString;
            string signature = oauthbase.GenerateSignature(new Uri(REQUEST_TOKEN_URL), token.consumerKey, token.consumerSecret,
                null, null, "GET", oauthbase.GenerateTimeStamp(), oauthbase.GenerateNonce(), out url, out queryString);

            queryString += "&oauth_signature=" + HttpUtility.UrlEncode(signature);

            return url + "?" + queryString;
        }

        public string GetAuthorizeUrl()
        {
            Dictionary<string, string> parameters = WebClient.String2Dictionary(WebClient.Get(GetRequestUrl(), ""));

            token.oAuthToken = parameters["oauth_token"];
            token.oAuthTokenSecret = parameters["oauth_token_secret"];
            return AUTHORIZE_TOKEN_URL + "?oauth_token=" + token.oAuthToken;
        }


        public string GetAccessUrl(string verifier)
        {
            string url;
            string queryString;

            string signature = oauthbase.GenerateSignature(new Uri(ACCESS_TOKEN_URL), token.consumerKey, token.consumerSecret,
                token.oAuthToken, token.oAuthTokenSecret, "POST", oauthbase.GenerateTimeStamp(), oauthbase.GenerateNonce(), out url, out queryString);
            queryString += "&oauth_signature=" + HttpUtility.UrlEncode(signature) + "&oauth_verifier=" + verifier;

            return url + "?" + queryString;
        }

        public bool GetAccessToken(string verifier)
        {
            Dictionary<string, string> parameters;
            try
            {
                parameters = WebClient.String2Dictionary(WebClient.Get(GetAccessUrl(verifier), ""));
            }
            catch (WebException)
            {
                return false;
            }
            token.oAuthToken = parameters["oauth_token"];
            token.oAuthTokenSecret = parameters["oauth_token_secret"];
            token.userId = parameters["user_id"];
            token.screenName = parameters["screen_name"];
            return true;
        }

        public string GetTimeline(int count)
        {
            string url;
            string queryString;
            Uri requestUri = new Uri("http://api.twitter.com/1/statuses/home_timeline.xml?count=" + count);
            string signature = oauthbase.GenerateSignature(requestUri, token.consumerKey, token.consumerSecret, token.oAuthToken, token.oAuthTokenSecret,
                "GET", oauthbase.GenerateTimeStamp(), oauthbase.GenerateNonce(), out url, out queryString);
            queryString += "&oauth_signature=" + HttpUtility.UrlEncode(signature);
            return WebClient.Get(url, queryString);
        }

        public void PostTweet(string tweet)
        {
            string url;
            string queryString;
            Uri requestUri = new Uri("http://api.twitter.com/1/statuses/update.xml?status=" + oauthbase.UrlEncode(tweet, Encoding.UTF8));
            string signature = oauthbase.GenerateSignature(requestUri, token.consumerKey, token.consumerSecret, token.oAuthToken, token.oAuthTokenSecret,
                "POST", oauthbase.GenerateTimeStamp(), oauthbase.GenerateNonce(), out url, out queryString);
            queryString += "&oauth_signature=" + HttpUtility.UrlEncode(signature);
            WebClient.Post(url, queryString);
        }
    }
}
