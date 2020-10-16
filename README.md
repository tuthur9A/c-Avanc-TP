# C# Avancé TP

Books
=============
#### API ENDPOINT
Get from Google : `https://{{Domaine}}/google?title=??&author=??`
GetAll books : `https://{{Domaine}}/`
search books in shelve : `https://{{Domaine}}/`

Shelve
=============
#### API ENDPOINT
GetAll shelves : `https://{{Domaine}}/shelves`

Search shelves by bookId  : `https://{{Domaine}}/shelves/search?id=??`

Post shelve : `https://{{Domaine}}/shelves/add`

with Object : 
```json
{
	"name":"string",
	"bookIds":["string","string"]
}
```
Add book to shelve : `https://{{Domaine}}/shelves/{shelveId}/add/book/{bookId}`

Remove book to shelve : `https://{{Domaine}}/shelves/{shelveId}/remove/book/{bookId}`

Post shelve : `https://{{Domaine}}/shelves/{id}/update`

with Object : 
```json
{
	"id":"string",
	"name":"string",
	"bookIds":["string","string"]
}
```
Delete shelve : `https://{{Domaine}}/shelves/{id}`

