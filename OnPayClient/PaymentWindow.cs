using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using OnPayClient.Exceptions;

namespace OnPayClient
{
    public class PaymentWindow
    {
        private string _gatewayId;
        private string _windowSecret;
        private string _currency;
        private int? _amount;
        private string _reference;
        private string _acceptUrl;
        private string _declineUrl;
        private string _callbackUrl;
        private string _type;
        private string _method;
        private bool _secureEnabled;
        private string _design;
        private string _language;
        private bool _testMode;
        private string _website;

        //OnPay Info
        private string _accountId;
        private DateTime? _accountCreatedDate;
        private DateTime? _accountChangedDate;
        private DateTime? _accountChangePasswordDate;
        private int? _accountPurchases;
        private int? _accountAttempts;
        private DateTime? _accountShippingFirstUseDate;
        private bool? _accountShippingIdenticalName;
        private bool? _accountSuspicious;
        private int? _accountAttemptsDay;
        private int? _accountAttemptsYear;
        private bool? _addressIdenticalShipping;
        private string _billingAddressCity;
        private int? _billingAddressCountry;
        private string _billingAddressLine1;
        private string _billingAddressLine2;
        private string _billingAddressLine3;
        private string _billingAddressPostalCode;
        private string _billingAddressState;

        private string _shippingAddressCity;
        private int? _shippingAddressCountry;
        private string _shippingAddressLine1;
        private string _shippingAddressLine2;
        private string _shippingAddressLine3;
        private string _shippingAddressPostalCode;
        private string _shippingAddressState;

        private string _name;
        private string _email;
        private string _homePhoneCc;
        private string _homePhoneNumber;
        private string _mobilePhoneCc;
        private string _mobilePhoneNumber;
        private string _workPhoneCc;
        private string _workPhoneNumber;
        private string _deliveryEmail;
        private int? _deliveryTimeFrame;
        private string _deliveryDisabled;

        private int? _giftCardAmount;
        private int? _giftCardCount;
        private bool? _preorder;
        private DateTime? _preorderDate;
        private bool? _reorder;
        private int? _shippingMethod;

        public PaymentWindow SetGatewayId(string gatewayId)
        {
            _gatewayId = gatewayId;
            return this;
        }

        public PaymentWindow SetWindowSecret(string windowSecret)
        {
            _windowSecret = windowSecret;
            return this;
        }

        public PaymentWindow SetCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public PaymentWindow SetAmount(decimal amount)
        {
            _amount = Convert.ToInt32(amount * 100);
            return this;
        }

        public PaymentWindow SetCallbackUrl(string callbackUrl)
        {
            _callbackUrl = callbackUrl;
            return this;
        }

        public PaymentWindow SetAcceptUrl(string acceptUrl)
        {
            _acceptUrl = acceptUrl;
            return this;
        }

        public PaymentWindow SetDeclineUrl(string declineUrl)
        {
            _declineUrl = declineUrl;
            return this;
        }

        public PaymentWindow SetReference(string reference)
        {
            _reference = reference;
            return this;
        }

        public PaymentWindow SetDesign(string design)
        {
            _design = design;
            return this;
        }

        public PaymentWindow SetMethod(string method)
        {
            _method = method.ToLower();
            return this;
        }

        public PaymentWindow SetType(string type)
        {
            _type = type.ToLower();
            return this;
        }

        public PaymentWindow SetLanguage(string language)
        {
            _language = language.ToLower();
            return this;
        }

        public PaymentWindow SetAccountId(string accountId)
        {
            _accountId = accountId;
            return this;
        }

        public PaymentWindow SetAccountCreatedDate(DateTime createdDate)
        {
            _accountCreatedDate = createdDate;
            return this;
        }

        public PaymentWindow SetAccountChangedDate(DateTime changedDate)
        {
            _accountChangedDate = changedDate;
            return this;
        }

        public PaymentWindow SetAccountChangedPasswordDate(DateTime changedDate)
        {
            _accountChangePasswordDate = changedDate;
            return this;
        }

        public PaymentWindow SetAccountPurchases(int purchases)
        {
            _accountPurchases = purchases;
            return this;
        }

        public PaymentWindow SetAccountAttempts(int attempts)
        {
            _accountAttempts = attempts;
            return this;
        }

        public PaymentWindow SetAccountShippingFirstUseDate(DateTime firstUse)
        {
            _accountShippingFirstUseDate = firstUse;
            return this;
        }

        public PaymentWindow SetAccountShippingIdenticalName(bool identical)
        {
            _accountShippingIdenticalName = identical;
            return this;
        }

        public PaymentWindow SetAccountSuspicious(bool suspicious)
        {
            _accountSuspicious = suspicious;
            return this;
        }

        public PaymentWindow SetAccountAttemptsDay(int attempts)
        {
            _accountAttemptsDay = attempts;
            return this;
        }

        public PaymentWindow SetAccountAttemptsYear(int attempts)
        {
            _accountAttemptsYear = attempts;
            return this;
        }

        public PaymentWindow SetAddressIdenticalShipping(bool identical)
        {
            _addressIdenticalShipping = identical;
            return this;
        }

        public PaymentWindow SetBillingAddressCity(string city)
        {
            _billingAddressCity = city;
            return this;
        }

        public PaymentWindow SetBillingAddressCountry(int country)
        {
            _billingAddressCountry = country;
            return this;
        }

        public PaymentWindow SetBillingAddressLine1(string line)
        {
            _billingAddressLine1 = line;
            return this;
        }

        public PaymentWindow SetBillingAddressLine2(string line)
        {
            _billingAddressLine2 = line;
            return this;
        }

        public PaymentWindow SetBillingAddressLine3(string line)
        {
            _billingAddressLine3 = line;
            return this;
        }

        public PaymentWindow SetBillingAddressPostalCode(string postalCode)
        {
            _billingAddressPostalCode = postalCode;
            return this;
        }

        public PaymentWindow SetBillingAddressState(string state)
        {
            _billingAddressState = state;
            return this;
        }

        public PaymentWindow SetShippingAddressCity(string city)
        {
            _shippingAddressCity = city;
            return this;
        }

        public PaymentWindow SetShippingAddressCountry(int country)
        {
            _shippingAddressCountry = country;
            return this;
        }

        public PaymentWindow SetShippingAddressLine1(string line)
        {
            _shippingAddressLine1 = line;
            return this;
        }

        public PaymentWindow SetShippingAddressLine2(string line)
        {
            _shippingAddressLine2 = line;
            return this;
        }

        public PaymentWindow SetShippingAddressLine3(string line)
        {
            _shippingAddressLine3 = line;
            return this;
        }

        public PaymentWindow SetShippingPostalCode(string postalCode)
        {
            _shippingAddressPostalCode = postalCode;
            return this;
        }

        public PaymentWindow SetShippingState(string state)
        {
            _shippingAddressState = state;
            return this;
        }

        public PaymentWindow SetName(string name)
        {
            _name = name;
            return this;
        }

        public PaymentWindow SetEmail(string email)
        {
            _email = email;
            return this;
        }

        public PaymentWindow SetHomePhoneCc(string phoneCode)
        {
            _homePhoneCc = phoneCode;
            return this;
        }

        public PaymentWindow SetHomePhoneNumber(string number)
        {
            _homePhoneNumber = number;
            return this;
        }

        public PaymentWindow SetWorkPhoneCc(string phoneCode)
        {
            _workPhoneCc = phoneCode;
            return this;
        }

        public PaymentWindow SetWorkPhoneNumber(string number)
        {
            _workPhoneNumber = number;
            return this;
        }

        public PaymentWindow SetMobilePhoneCc(string phoneCode)
        {
            _mobilePhoneCc = phoneCode;
            return this;
        }

        public PaymentWindow SetMobilePhoneNumber(string number)
        {
            _mobilePhoneNumber = number;
            return this;
        }

        public PaymentWindow SetDeliveryEmail(string email)
        {
            _deliveryEmail = email;
            return this;
        }

        public PaymentWindow SetDeliveryTimeFrame(int timeFrame)
        {
            _deliveryTimeFrame = timeFrame;
            return this;
        }

        public PaymentWindow SetDeliveryDisabled(string deliveryDisabled)
        {
            _deliveryDisabled = deliveryDisabled;
            return this;
        }

        public PaymentWindow SetGiftCardAmount(int amount)
        {
            _giftCardAmount = amount;
            return this;
        }

        public PaymentWindow SetGiftCardCount(int count)
        {
            _giftCardCount = count;
            return this;
        }

        public PaymentWindow SetPreorder(bool preorder)
        {
            _preorder = preorder;
            return this;
        }

        public PaymentWindow SetPreorderDate(DateTime date)
        {
            _preorderDate = date;
            return this;
        }

        public PaymentWindow SetReorder(bool reorder)
        {
            _reorder = reorder;
            return this;
        }

        public PaymentWindow SetShippingMethod(int shippingMethod)
        {
            _shippingMethod = shippingMethod;
            return this;
        }

        public PaymentWindow EnableTestMode()
        {
            _testMode = true;
            return this;
        }

        public PaymentWindow Enable3DSecure()
        {
            _secureEnabled = true;
            return this;
        }

        public PaymentWindow SetWebsite(string url)
        {
            _website = url;
            return this;
        }


        public Dictionary<string, string> GenerateParams()
        {
            ValidateWindow();

            // Setup parameter list
            var windowParams = new Dictionary<string, string> {
                { "onpay_gatewayid", _gatewayId },
                { "onpay_currency", _currency },
                { "onpay_amount", _amount.ToString() },
                { "onpay_reference", _reference },
                { "onpay_accepturl", _acceptUrl },
                { "onpay_callbackurl", _callbackUrl },
                { "onpay_declineurl", _declineUrl },
                { "onpay_type", _type },
                { "onpay_method", _method },
                { "onpay_language", _language },
                { "onpay_design", _design },
                { "onpay_testmode", _testMode ? "1" : "0" },
                { "onpay_3dsecure", _secureEnabled ? "forced" : "" },
                { "onpay_website", _website }
            };

            AddInfoParameters(windowParams);

            // Add platform
            var version = Assembly.GetExecutingAssembly()
                                  .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                  .InformationalVersion;
            windowParams.Add("onpay_platform", $".NET SDK/{version}");

            // Generate HMAC
            var hmac = GenerateSha1(windowParams, _windowSecret);
            windowParams.Add("onpay_hmac_sha1", hmac);

            return windowParams;
        }

        private string GenerateSha1(Dictionary<string, string> inputParams, string key)
        {
            var orderedParams = inputParams.OrderBy(x => x.Key);

            var queryStringHelper = HttpUtility.ParseQueryString(string.Empty);
            foreach (var pair in orderedParams)
                queryStringHelper.Add(pair.Key, pair.Value);

            var queryString = queryStringHelper.ToString();

            var generatedSha1 = Encode(queryString, Encoding.UTF8.GetBytes(key));

            return generatedSha1;
        }

        private string Encode(string input, byte[] key)
        {
            var myhmacsha1 = new HMACSHA1(key);
            var byteArray = Encoding.ASCII.GetBytes(input);
            var stream = new MemoryStream(byteArray);
            return myhmacsha1
                .ComputeHash(stream)
                .Aggregate("", (s, e) => s + $"{e:x2}", s => s);
        }

        private void ValidateWindow()
        {
            void ValidateParameter(string name, string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new PaymentWindowValidationException { ParameterName = name };
            }

            ValidateParameter("Gateway Id", _gatewayId);
            ValidateParameter("Currency", _currency);
            ValidateParameter("Reference", _reference);
            ValidateParameter("Accept URL", _acceptUrl);
            ValidateParameter("Amount", _amount.ToString());
            ValidateParameter("Window secret", _windowSecret);
        }

        private void AddInfoParameters(IDictionary<string, string> parameters)
        {
            void AddString(IDictionary<string, string> @params, string name, string value)
            {
                if (!string.IsNullOrWhiteSpace(value))
                    @params.Add(name, value);
            }

            void AddDate(IDictionary<string, string> @params, string name, DateTime? value)
            {
                if (value.HasValue)
                    @params.Add(name, value.Value.ToString("yyyy-MM-dd"));
            }

            void AddBool(IDictionary<string, string> @params, string name, bool? value)
            {
                if (value.HasValue)
                    @params.Add(name, value == true ? "Y" : "N");
            }

            void AddInt(IDictionary<string, string> @params, string name, int? value, string format = "")
            {
                if (value.HasValue)
                    @params.Add(name, value.Value.ToString(format));
            }

            AddString(parameters, "onpay_info_account_id", _accountId);
            AddDate(parameters, "onpay_info_account_date_created", _accountCreatedDate);
            AddDate(parameters, "onpay_info_account_date_change", _accountChangedDate);
            AddDate(parameters, "onpay_info_account_date_password_change", _accountChangePasswordDate);
            AddInt(parameters, "onpay_info_account_purchases", _accountPurchases);
            AddInt(parameters, "onpay_info_account_attempts", _accountAttempts);
            AddDate(parameters, "onpay_info_account_shipping_first_use_date", _accountShippingFirstUseDate);
            AddBool(parameters, "onpay_info_account_shipping_identical_name", _accountShippingIdenticalName);
            AddBool(parameters, "onpay_info_account_suspicious", _accountSuspicious);
            AddInt(parameters, "onpay_info_account_attempts_day", _accountAttemptsDay);
            AddInt(parameters, "onpay_info_account_attempts_year", _accountAttemptsYear);
            AddBool(parameters, "onpay_info_address_identical_shipping", _addressIdenticalShipping);
            AddString(parameters, "onpay_info_billing_address_city", _billingAddressCity);
            AddInt(parameters, "onpay_info_billing_address_country", _billingAddressCountry);
            AddString(parameters, "onpay_info_billing_address_line1", _billingAddressLine1);
            AddString(parameters, "onpay_info_billing_address_line2", _billingAddressLine2);
            AddString(parameters, "onpay_info_billing_address_line3", _billingAddressLine3);
            AddString(parameters, "onpay_info_billing_address_postal_code", _billingAddressPostalCode);
            AddString(parameters, "onpay_info_billing_address_state", _billingAddressState);
            AddString(parameters, "onpay_info_shipping_address_city", _shippingAddressCity);
            AddInt(parameters, "onpay_info_shipping_address_country", _shippingAddressCountry);
            AddString(parameters, "onpay_info_shipping_address_line1", _shippingAddressLine1);
            AddString(parameters, "onpay_info_shipping_address_line2", _shippingAddressLine2);
            AddString(parameters, "onpay_info_shipping_address_line3", _shippingAddressLine3);
            AddString(parameters, "onpay_info_shipping_address_postal_code", _shippingAddressPostalCode);
            AddString(parameters, "onpay_info_shipping_address_state", _shippingAddressState);
            AddString(parameters, "onpay_info_name", _name);
            AddString(parameters, "onpay_info_email", _email);
            AddString(parameters, "onpay_info_phone_home_cc", _homePhoneCc);
            AddString(parameters, "onpay_info_phone_home_number", _homePhoneNumber);
            AddString(parameters, "onpay_info_phone_mobile_cc", _mobilePhoneCc);
            AddString(parameters, "onpay_info_phone_mobile_number", _mobilePhoneNumber);
            AddString(parameters, "onpay_info_phone_work_cc", _workPhoneCc);
            AddString(parameters, "onpay_info_phone_work_number", _workPhoneNumber);
            AddString(parameters, "onpay_info_delivery_email", _deliveryEmail);
            AddInt(parameters, "onpay_info_delivery_time_frame", _deliveryTimeFrame, "D2");
            AddString(parameters, "onpay_delivery_disabled ", _deliveryDisabled);
            AddInt(parameters, "onpay_info_gift_card_amount", _giftCardAmount);
            AddInt(parameters, "onpay_info_gift_card_count", _giftCardCount);
            AddBool(parameters, "onpay_info_preorder", _preorder);
            AddDate(parameters, "onpay_info_preorder_date", _preorderDate);
            AddBool(parameters, "onpay_info_reorder", _reorder);
            AddInt(parameters, "onpay_info_shipping_method", _shippingMethod, "D2");
        }
    }
}
