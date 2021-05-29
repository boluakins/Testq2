# InterviewTest
dtoaa, commons and services folders were not implemented in separate class libraries due to the nature of the project (simple test project) 

question 2 endpoints
  
  2a   https://test-q2.herokuapp.com/card-scheme/verify/534352
  
        
  2b   default start and limit values are 1 and 3 respectively. There are 6 records
       https://test-q2.herokuapp.com/card-scheme/stats?start={}&limit={}
  
  2c  added isValid field to reponse body to state whether card is valid or not. 
      https://test-q2.herokuapp.com/card-scheme/verify-optimized/534352
