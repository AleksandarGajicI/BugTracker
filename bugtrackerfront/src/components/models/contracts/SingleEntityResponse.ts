interface SingleEntityDto<T> {
  entityDTO: T;
  success: Boolean;
  errors: String[];
}

export default SingleEntityDto;
