# SBUResearch487-WindowsAPP
SBUResearch487-WindowsAPP

I developed Windows Application Based on C# .Net Framework for monitoring weather data and enery consumption connecting with Google Cloud Platform Firestore.

Following Sources are for loading weather data from Google Cloud Platform Firestore. This is for reading data from GCP
#### 
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("RealTimeData_Test");
            Query query = usersRef.OrderByDescending("Date").Limit(1);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                frm.w_value1.Text = documentDictionary["Avg_Temp"].ToString() + " \'C";
                frm.w_value2.Text = documentDictionary["Humidity"].ToString() + " %";
                frm.w_value3.Text = documentDictionary["Pressure"].ToString() + " hPa";
                frm.w_value4.Text = documentDictionary["Wind"].ToString() + " Km/h";
                frm.w_value5.Text = documentDictionary["High_Temp"].ToString() + " \'C";
                frm.w_value6.Text = documentDictionary["Low_Temp"].ToString() + " \'C";
            }
            
#### Followings are for User Account information. I used this sources for writing new data and storing into Google Cloud Platform Firestore.
#### This is for writing data into GCP


            FirestoreDb db = FirestoreDb.Create(project);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", project);

            DocumentReference docRef = db.Collection("users").Document(userID);
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "userName", userName },
                { "userPassword", userPassword },
                { "userNickName", userNickName },

                { "userID", userID },
                { "userKey", userKey },
                { "userEmail", userEmail },
                { "userPhone", userPhone },
                { "userHouseID", userHouseID },
                
                { "userCountry", userCountry },
                { "userProvince", userProvince },
                { "userHouseNumber", userHouseNumber },
                { "userHouseAddress", userHouseAddress },
                { "userLocationLatitude", userLocationLatitude },

                { "userCityID","Seoul"},
                { "userCityName","Seoul"},
                { "userZipCode","12345"},


                { "userElectMeterID", userElectMeterID },
                { "userTempID", userTempID },
                { "userHumidID", userHumidID  },
          
                { "userElectDate", userElectDate },
                { "userTempDate", userTempDate },
                { "userHumidDate", userHumidDate }
            };
            docRef.SetAsync(user);
            
####
