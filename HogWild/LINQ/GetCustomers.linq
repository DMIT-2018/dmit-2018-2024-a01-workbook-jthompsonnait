<Query Kind="Program">
  <Connection>
    <ID>7feab626-14df-4634-b90d-faf30c4fafbb</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>OLTP-DMIT2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	GetCustomers("Fo", "7809753079").Dump();
}

public List<CustomerSearchView> GetCustomers(string lastName, string phone)
{
	// Business Rules
	// These are processing rules that need to be satisfied
	// for valid data

	// Rule: Both last name and phone number cannot be empty
	// Rule: RemoveFromViewFlag must be false
	if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(phone))
	{
		throw new ArgumentNullException("Please provide either a last name and/or phone number");
	}

	// Need to update parameters so we are not searching on an empty value.
	// Otherwise, an empty string will return all records
	if (string.IsNullOrWhiteSpace(lastName))
	{
		lastName = Guid.NewGuid().ToString();
	}

	if (string.IsNullOrWhiteSpace(phone))
	{
		phone = Guid.NewGuid().ToString();
	}

	return Customers
				.Where(x => (x.LastName.Contains(lastName.Trim())
							 || x.Phone.Contains(phone.Trim()))
							&& !x.RemoveFromViewFlag)
				.Select(x => new CustomerSearchView
				{
					CustomerID = x.CustomerID,
					FirstName = x.FirstName,
					LastName = x.LastName,
					City = x.City,
					Phone = x.Phone,
					Email = x.Email,
					StatusID = x.StatusID,
					TotalSales = x.Invoices.Sum(x => x.SubTotal + x.Tax)
				})
				.OrderBy(x => x.LastName)
				.ToList();
}



public class CustomerSearchView
{
	public int CustomerID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string City { get; set; }
	public string Phone { get; set; }
	public string Email { get; set; }
	public int StatusID { get; set; }
	public decimal? TotalSales { get; set; }
}