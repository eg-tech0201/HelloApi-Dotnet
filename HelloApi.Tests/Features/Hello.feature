Feature: Hello API

    Scenario: Missing firstname returns 400
        When I GET "/api/hello"
        Then the response status should be 400
    
    Scenario: Firstname returns greeting
        When I GET "/api/hello?firstname=Esha"
        Then the response status should be 200
        And the JSON field "message" should be "Hi Esha"