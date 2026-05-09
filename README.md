## MULTI TIER NOTIFICATION APPLICATION

## STEPS

1. Create Model class Library
2. Create Data Access Library
3. Create Buisness Layer Library
4. Create Presentation Layer (Console App)
5. Add Reference from Model - Data Acess - Buisness Layer - Presentation

## Model Library

1. The Models Library will be created for
    - User
    - Company
    - Notification

2. Override of string is created to print the values along with keys.

3. The Model Library is created along with the Custom Exception

    - Email Exception
        - Email validation is checked
        - The message can be passed as the parameter
    - Message Exception 
        - Given condition are made in the exception
        - Check the WhiteSpace
        - Check the Message Length (not greater than 5)
        - SMS Message length should not be greater than 160
    - NotificationNotFoundException 
        - no notification found in the list that is got from the repository
        -empty notification
    - PhoneNumberException 
        - Phone Number is not valid
        - The message is passed as paramter
    - UserNotFoundException 
        - no user found in the list that is got from the repository

Note - Model Library is used for storing the database models and its structure no logical things are done over here.

## Data Access Library

Here The access of database is done where updation,creation and deletion are done and can be accessed only by this layer.

Folder Structure

- Interfaces
    
    - INotificationRepository (additional notification functions)
    - IRepository (common functions for all repos)
    - No IUser created as for now no additional functions are needed

- Repositories

    - AbstractRepository (implement IRepository where common functions are defined)
    - NotificationRepository (create function and other additional function such as userId,service filteration are added for particular repo)
    - UserRepository (create function)
Repositories are created

Interface created for the Repository (Basic CRUD Operations)

- Create
- Delete
- Update
- Get Operation By Id
- Get All User

This interface repository is used for all the Data and an Abstract class can be defined as the functions are similar and no repetation of the code is not needed.

It can be inherited.

AbstractRepository created implementing the IRepository

- Update
- Delete
- Get By iD
- Get All

these functions are similar so no needed to create this for all the model that are created.

- Create function 
    
    - will be different as the attributes and validation are needed to be done which will differ for different for each model. 
    - so the class repository for other models that are inherited can override the function 

Note - The other functions for each repostory can be additionally added if required as per the requirements

The Repositories that are created
- User Repository
- Notification Repository

User Repository

- create function created
- static variable createad for userId
- userId will be increased for each user addition
- all the attributes are validated in the presentation and buisness layer itself

Notification Repository

- GetNotificationByUserIdAndService(int userId,string service)
- GetNotificationByUserId(int userId)
- GetNotificationByService(string service)

All these returns the List here these are additional functions that are added only in the Notification Repo as only used in only notification

These repository are found in the INotificationRepository

**Notification Repository implements both the IRepository and the INotificationRepository** 

## Buisness Layer Library

Folder Structure

- Delegates

    - AddUserDelegate
    - DeleteUserDelegate
    - UpdationUserDelegate
    - NotificationDelegate

- InputsCheck

    - InputCheck (check the inputs validation such as email,phone number,message,id)

- Interfaces

    - INotificationSenderService
    - INotificationService
    - IUserService

- Services

    - Notification
        
        - GetNotificationService (get the notification by userid,service etc)
        - NotificationService (send notification where the type of service is decided and which kind service needed to be called)

    - NotificationSender

        - Email

            - EmailService
            - Email LogService
        
        - SMS

            - SMSService
            - SMS LogService
        
        - Notification.cs file (main file)
        
    - User

        - DelegateService

            - UserAddService.cs
            - UserDeleteService.cs
            - UserUpdateService.cs

        - MainService

            - UserServiceByEmail.cs
            - UserServiceById.cs
            - UserServiceByPhone.cs

        - UserServiceMain.cs

    - Validation

        - EmailValidation.cs
        - MessageValidation.cs
        - PhoneNumberValidation.cs
    

**Delegate**

A delegate in C# is a type-safe function pointer that allows you to reference and call methods dynamically. It essentially treats a method as an object, allowing you to pass a method as a parameter to another method or assign it to a variable

Note - Parameters and return type should be same for the all the functions used in the delegate

- AddUserDelegate

    - Here delegation is used adding the user and then send the notification via the SMS and Email

- DeleteUserDelegate

    - Here delegation is used deleting the user and then send the notification via the SMS and Email

- UpdationUserDelegate

    - Here delegation is used updating the user and then send the notification via the SMS and Email

- NotificationDelegate

    - ValidateTheMessage
    - SendNotification
    - SaveNotification
    - LogNotification

**InputsCheck**

Used to check if the inputs are entered correctly or not.If not again loop will be used untill correct input is entered.

- EmailInput
- SMSInput
- IDInput
- MessageInput

**Interfaces**

- INotificationSenderService.cs (send the message)
- INotificationService.cs (specific for notification list access like get notification by id,service etc)
- IUserService.cs (user crud operation)

**Services**

- Notification

    - SendNotification(message,service,user)
    - PrintNotification()
    - GetNotificationByUserId(userId)
    - GetNotificationById(id)
    - GetNotificationByService(service)
    - GetNotificationByUserIdAndService(userId,service)

- NotificationSender

    Implements the INotificationSenderService

    - ValidationOfMessage()
    - SendNotification()
    - SaveNotification()
    - LogNotification()

    Implemented by delegation for sending the notification

- Email (Override functions) (real email notification sending implemeneted)

    - SendNotification
    - LogNotification

- SMS (Override functions) (only console print)

    - SendNotification
    - LogNotification

- User

    - DelegateService

        - UserAddService.cs
        - UserDeleteService.cs
        - UserUpdateService.cs
        
    - Main Service

        - UserServiceByEmail

            - GetUserByEmail
            - DeleteUserByEmail

        - UserServiceByPhone

            - GetUserByPhone
            - DeleteUserByPhone
        
        - UserServiceById

            - GetUserByEmail
            - DeleteUserByEmail
            - UpdateUserById

        - UserServiceMain.cs

- Validation

    - EmailValidation (Regex)
    - PhoneNumberValidation (Regex)
    - MessageValidation (Conditions)

## Presentation Layer

Roles

- Admin
- User

Admin

- Add User
- Delete User
    - Delete User By UserId
    - Delete User By Phone Number
    - Delete User By Email
- Update The User
- Get The User
    - Get User By Id
    - Get User By Email
    - Get User By PhoneNumber
    - Get All User
- Deliver Message
    - Email
    - SMS   
- Notification
    - Display By UserId
    - Display All
    - Display By Id

User

 - Display the notification by user Id
 - display the notificaiton by service
 - display the notification by userid and service

The files in the project is origanised by the usage of partial class

By cliking the needed options the logic passess

Add User

- Usage of delegates for adding the user to the Dictionary and send notificaiton (both sms and email)
- check the phone number and email id
- no duplicate email user can be added
- phone number duplication for a user is allowed
- a user can have only one email and multiple phone number for registration of user account
- once inputs are checked user added to dictionary
- after creation notification is sent 

Get User

- GetUserById

    - id input is validated (only number greater than 0)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created

- GetUserByEmail

    - email is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created

- GetUserByPhone

    - phone number is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created

- GetAllUser

    - Call the user service which implemets the IUserService
    - User List or empty list is returned
    - the service is passed to repo and the data is returned
    - if user list empty an exception is thrown UserNotFoundExcpetion which is custom created

DisplayTheNotification

- GetNotificationAll

    - Call the notification service which implemets the INotificationService
    - Notification or null is returned
    - the service is passed to repo and the data is returned
    - if notification list is empty an exception is thrown NotificationNotFoundExcpetion which is custom created

- GetNotificationById

    - id input is validated (only number greater than 0)
    - Call the notification service which implemets the INotificationService
    - Notification or null is returned
    - the service is passed to repo and the data is returned
    - if notification null an exception is thrown NotificationNotFoundExcpetion which is custom created

- GetNotificationByUserId

    - userid input is validated (only number greater than 0)
    - validate the user if user already registered or not.
    - If not then user then throw new UserNotFoundException
    - Call the notification service which implemets the INotificationService
    - Notification List or empty list is returned
    - the service is passed to repo and the data is returned
    - if notification list is empty an exception is thrown NotificationNotFoundExcpetion which is custom created

- GetNotificationByUserIdAndService

    - userid input is validated (only number greater than 0)
    - validate the user if user already registered or not.
    - If not then user then throw new UserNotFoundException
    - Call the notification service which implemets the INotificationService
    - Notification List or empty list is returned 
    - filter done based on service type also (email and sms)
    - the service is passed to repo and the data is returned
    - if notification list is empty an exception is thrown NotificationNotFoundExcpetion which is custom created

Delete User

- Usage of delegates for deleting the user to the Dictionary and send notificaiton (both sms and email)

- DeleteUserById

    - id input is validated (only number greater than 0)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created
    - if user found with that id is deleted.

- DeleteUserByEmail

    - email is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned by checking if user registered or not
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created
    - if user found then registered user with that email is deleted

- DeleteUserByPhone

    - phone number is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned by checking if user registered or not
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created
    - if user found then all the resgistered user with that phone number is deleted
    - all user with the registered phone number is deleted.

- Update user

    - Usage of delegates for updating the user to the Dictionary and send notificaiton (both sms and email)
    - check the phone number and email id
    - no duplicate email user can be added
    - check the entered email is not already registered. if found then not possible
    - phone number duplication for a user is allowed
    - a user can have only one email and multiple phone number for registration of user account
    - once inputs are checked user updated to dictionary
    - after updation notification is sent 

All the Needed object such as the service,repo are created in presentation layer and passed in constructor