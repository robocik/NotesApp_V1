# Jak uruchomić projekt?

### Utworzenie bazy danych
1. Stwój czystą bazę w Sql Server
2. Uruchom na tej bazie ten skrypt: https://github.com/nhibernate/NHibernate.AspNetCore.Identity/blob/master/database/mssql/00_aspnet_core_identity.sql
3. W projekcie **NoteBookApp.Server** znajdziesz w katalogu **Infrastructure** plik **DbCreate.sql**. Uruchom go na swojej bazie.
4. Podaj connection stringa do bazy w pliku **appsettings.json**
