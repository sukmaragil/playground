Feature: POST API demo

Background:
  * url 'https://reqres.in/api'
  * header Accept = 'application/json'
  * def expectedResponse = read('create-user.json')

Scenario: Post Demo - using normal request
  Given url 'https://reqres.in/api/users'
  And request { "name": "morpheus", "job": "leader" }
  When method POST
  Then status 201

Scenario: Post Demo - using background
  Given path '/users'
  And request { "name": "morpheus", "job": "leader" }
  When method POST
  Then status 201
  And print response

Scenario: Post Demo - Using matcher
  Given path '/users'
  And request { "name": "Uup", "job": "teacher" }
  When method POST
  Then status 201
  And match response == { "name": "Uup", "job": "teacher", "id": "#string", "createdAt": "#ignore" }
  And print response

Scenario: Post Demo - Using matcher and file for response
  Given path '/users'
  And request { "name": "Uup", "job": "teacher" }
  When method POST
  Then status 201
  And match response == expectedResponse
  And match $ == expectedResponse

Scenario: Post Demo - Using file from another folder for request body
  Given path '/users'
  And def payload = read('classpath:examples/data/request-body.json')
  And request payload
  When method POST
  Then status 201
  And match response == expectedResponse

Scenario: Post Demo - Using matcher and file for response, using user.dir karate properties
  Given path '/users'
  And def projectPath = karate.properties['user.dir']
  And print projectPath
  And def filePath = projectPath+'/src/test/java/examples/data/request-body.json'
  And def requestBody = filePath
  And request requestBody
  When method POST
  Then status 201
  And match response == expectedResponse

Scenario: Post Demo - Modify request body
  Given path '/users'
  And def payload = read('classpath:examples/data/request-body.json')
  And set payload.job = 'engineer'
  And request payload
  When method POST
  Then status 201
  And set expectedResponse.job = 'engineer'
  And match response == expectedResponse