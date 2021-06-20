import requests

ENDPOINT = "https://sister-versioning-serverapi.azurewebsites.net/api/versioning"

def get(version = ''):
    res = requests.get(f'{ENDPOINT}/{version}')
    assert res.status_code == 200
    return res.json()

def post(data):
    res = requests.post(ENDPOINT, json=data)
    assert res.status_code == 200

post({
  "version": "3.0.0",
  "link": "https://firebasestorage.googleapis.com/v0/b/sister-versioning.appspot.com/o/helloworld3.exe?alt=media&token=da6e23a5-0322-430d-b19a-c722be322220",
  "description": "Ini update bisa download lewat firebase"
})

post({
  "version": "4.0.0",
  "link": "https://firebasestorage.googleapis.com/v0/b/sister-versioning.appspot.com/o/helloworld4.exe?alt=media&token=574c21f9-e63f-48ce-8108-2020d17ec48e",
  "description": "Ini download dari firebase, main programnya blocking jadi gk langsung ngeclose"
})

#print(get("3.0.0"))
print(get())