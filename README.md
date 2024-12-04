# Web API BUILD WITH ASP.NET 5.0

## Technologi:
    - ASP.NET Core 5.0
    - Entity Framework


## Package
- Microsoft.AspNetCore.App vì tầng Application sẽ phải chạy ngang hàng với tầng WebApp nên phải thêm Microsoft.AspNetCore.App vào tầng Application để chạy được IWebHostEnvironment

- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
3 Package dùng để thao tác ở tầng Data (Dữ liệu Entity) giúp sửa các trường, thuộc tính của cột và bảng. 'Tools' sẽ giúp thao tác với database bằng lệnh console dễ hơn. Nếu không sử dụng SQL Server thì có thể không cần cài Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Json
2 Package dùng để đọc file json, ở đây là file appsettings.json, vì connectionstring kết nối tới database được lưu trong file này. Việc đọc được file giúp thao tác với database và Entity gọn hơn.
## How to config and run:



### Solution structure:
    +> NLayer: (Data, Business, Presentation) Data Driven design
    +> DDD (Dommanin Driven Design) 
### Web Apllication

