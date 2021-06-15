interface GetAllDto<T> {
  errors: String[];
  success: Boolean;
  foundEntitiesDTO: T;
}

export default GetAllDto;
