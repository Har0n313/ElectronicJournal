using ElectronicJournal.Domain.Entites;
using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.SchoolDtos;

public sealed record SearchSchoolRequest(ODataQueryOptions<School> ODataOptions);